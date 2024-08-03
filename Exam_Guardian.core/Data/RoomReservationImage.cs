using System;
using System.Collections.Generic;

namespace Exam_Guardian.core.Data
{
    public partial class RoomReservationImage
    {
        public string? Place { get; set; }
        public decimal? ExamReservationId { get; set; }
        public string? Path { get; set; }
        public decimal RoomReservationImageId { get; set; }

        public virtual ExamReservation? ExamReservation { get; set; }
    }
}
