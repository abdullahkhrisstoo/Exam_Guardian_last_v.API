using System;
using System.Collections.Generic;

namespace Exam_Guardian.core.Data
{
    public partial class Examreservationstate
    {
        public Examreservationstate()
        {
            ExamReservations = new HashSet<ExamReservation>();
        }

        public decimal Examreservationstateid { get; set; }
        public string? Examreservationstate1 { get; set; }

        public virtual ICollection<ExamReservation> ExamReservations { get; set; }
    }
}
