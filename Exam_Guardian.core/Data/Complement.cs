using System;
using System.Collections.Generic;

namespace Exam_Guardian.core.Data
{
    public partial class Complement
    {
        public decimal ComplementId { get; set; }
        public string? ProctorDesc { get; set; }
        public string? StudentDesc { get; set; }
        public decimal? ExamReservationId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ExamReservation? ExamReservation { get; set; }
    }
}
