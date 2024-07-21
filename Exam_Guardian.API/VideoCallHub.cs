//using Microsoft.AspNetCore.SignalR;
//using System.Collections.Concurrent;

//namespace Exam_Guardian.API
//{
//    public class VideoCallHub : Hub
//    {
//        private static ConcurrentDictionary<string, string> connectedClients = new ConcurrentDictionary<string, string>();

//        public override async Task OnConnectedAsync()
//        {
//            await base.OnConnectedAsync();

//            // Add client to dictionary with connectionId as key and userId as value
//            connectedClients.TryAdd(Context.ConnectionId, Context.UserIdentifier);

//            // Limit the number of clients to two for a peer-to-peer call
//            if (connectedClients.Count > 2)
//            {
//                await Clients.Caller.SendAsync("CallRejected", "Only two participants are allowed.");
//                Context.Abort();
//            }
//        }

//        public override async Task OnDisconnectedAsync(Exception exception)
//        {
//            // Remove client from dictionary on disconnect
//            connectedClients.TryRemove(Context.ConnectionId, out _);

//            await base.OnDisconnectedAsync(exception);
//        }

//        public async Task SendSDP(string targetUserId, string sdpMid, string sdp)
//        {
//            if (connectedClients.TryGetValue(Context.ConnectionId, out string senderUserId)
//                //&&
//                //connectedClients.ContainsValue(targetUserId)
//                )
//            {
//                // Send SDP to the specific target user
//                await Clients.User(targetUserId).SendAsync("ReceiveSDP", senderUserId, sdpMid, sdp);
//            }
//        }

//        public async Task SendICE(string targetUserId, string candidate, string sdpMid, int sdpMLineIndex)
//        {
//            if (connectedClients.TryGetValue(Context.ConnectionId, out string senderUserId) 
//                //&&
//                //connectedClients.ContainsValue(targetUserId)
//                )
//            {
//                // Send ICE candidate to the specific target user
//                await Clients.User(targetUserId).SendAsync("ReceiveICE", senderUserId, candidate, sdpMid, sdpMLineIndex);
//            }
//        }
//    }

//}
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Exam_Guardian.API
{
    public class VideoCallHub : Hub
    {
        private static readonly ConcurrentDictionary<string, string> userRooms = new ConcurrentDictionary<string, string>();

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            await Clients.Caller.SendAsync("Connected", Context.ConnectionId);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            if (userRooms.TryRemove(Context.ConnectionId, out var roomName))
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
            }

            await base.OnDisconnectedAsync(exception);
        }

        public async Task JoinRoom(string roomName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomName);
            userRooms.TryAdd(Context.ConnectionId, roomName);
            await Clients.Group(roomName).SendAsync("RoomJoined", Context.ConnectionId);
        }

        public async Task SendSDP(string roomName, string sdpMid, string sdp)
        {
            if (userRooms.ContainsKey(Context.ConnectionId))
            {
                await Clients.OthersInGroup(roomName).SendAsync("ReceiveSDP", Context.ConnectionId, sdpMid, sdp);
            }
            else
            {
                await Clients.Caller.SendAsync("Error", "You are not in a room");
            }
        }

        public async Task SendICE(string roomName, string candidate, string sdpMid, int sdpMLineIndex)
        {
            if (userRooms.ContainsKey(Context.ConnectionId))
            {
                await Clients.OthersInGroup(roomName).SendAsync("ReceiveICE", Context.ConnectionId, candidate, sdpMid, sdpMLineIndex);
            }
            else
            {
                await Clients.Caller.SendAsync("Error", "You are not in a room");
            }
        }
    }
}

