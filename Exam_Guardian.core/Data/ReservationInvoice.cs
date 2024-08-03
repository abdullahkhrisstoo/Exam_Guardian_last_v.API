using System;
using System.Collections.Generic;

namespace Exam_Guardian.core.Data
{
    public partial class ReservationInvoice
    {
        public decimal? ExamReservationId { get; set; }
        public decimal? Value { get; set; }
        public DateTime? CreatedAt { get; set; }
        public decimal ReservationInvoiceId { get; set; }

        public virtual ExamReservation? ExamReservation { get; set; }
    }
}
