using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.DTO
{
    public class UpdateReservationInvoiceDTO
    {
        public decimal ReservationInvoiceId { get; set; }
        public decimal? ExamReservationId { get; set; }
        public decimal? Value { get; set; }
    }

}
