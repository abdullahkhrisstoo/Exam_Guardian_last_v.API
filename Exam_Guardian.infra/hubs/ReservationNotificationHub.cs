using Exam_Guardian.core.DTO;
using Microsoft.AspNetCore.SignalR;

namespace Exam_Guardian.infra.hubs
{
    public class ReservationNotificationHub:Hub
    {

        public async Task SendReservationNotification(ReservationInvoiceDetailsDTO reservationInvoiceDetailsDTO)
        {
            await Clients.Others.SendAsync("ReceiveReservationNotification", reservationInvoiceDetailsDTO);
            Console.WriteLine("ReceiveOffer");
        }

    }
}
