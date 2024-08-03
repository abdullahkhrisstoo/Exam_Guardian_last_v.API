using Exam_Guardian.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.IRepository
{
    public interface IReservationInvoiceRepository
    {
        Task<int> CreateReservationInvoice(CreateReservationInvoiceDTO createDto);
        Task<int> DeleteReservationInvoice(decimal id);
        Task<int> UpdateReservationInvoice(UpdateReservationInvoiceDTO updateDto);
        Task<ReservationInvoiceDTO> GetReservationInvoiceById(decimal id);
        Task<IEnumerable<ReservationInvoiceDTO>> GetAllReservationInvoices();
        Task<IEnumerable<ReservationInvoiceDetailsDTO>> GetAllReservationInvoicesDetails();
    }

}
