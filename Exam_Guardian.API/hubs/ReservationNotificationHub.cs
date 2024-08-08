using Exam_Guardian.core.DTO;
using Exam_Guardian.core.Utilities.CalimHandler;
using Exam_Guardian.core.Utilities.UserRole;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace Exam_Guardian.API.hubs
{

    public class ReservationNotificationHub : Hub
    {

        public override async Task OnConnectedAsync()
        {
            var roleId = Context.User?.FindFirst("RoleId")?.Value;

            if (roleId != null)
            {
         
                if (roleId == UserRoleConstant.SAdmin)
                {
                    await Groups.AddToGroupAsync(Context.ConnectionId, "Admins");
                }
              
              
            }

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
           
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "Admins");

            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendReservationNotification(ReservationInvoiceDetailsDTO reservationInvoiceDetailsDTO)
        {
        
            await Clients.Group("Admins").SendAsync("ReceiveReservationNotification", reservationInvoiceDetailsDTO);
            Console.WriteLine("Reservation notification sent to Admins.");
        }
    }
}
