using System;
using System.Collections.Generic;

namespace Exam_Guardian.core.Data
{
    public partial class IdentificationImage
    {
        public string? PathImageBack { get; set; }
        public string? PathImageFront { get; set; }
        public decimal? ExamReservationId { get; set; }
        public decimal IdentificationImageId { get; set; }

        public virtual ExamReservation? ExamReservation { get; set; }
    }
}
