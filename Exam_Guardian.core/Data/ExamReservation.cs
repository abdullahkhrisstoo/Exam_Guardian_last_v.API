using System;
using System.Collections.Generic;

namespace Exam_Guardian.core.Data
{
    public partial class ExamReservation
    {
        public ExamReservation()
        {
            Complements = new HashSet<Complement>();
        }

        public decimal ExamReservationId { get; set; }
        public string? StudentTokenEmail { get; set; }
        public string? ProctorTokenEmail { get; set; }
        public string? UniqueKey { get; set; }
        public decimal? UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? StudentName { get; set; }
        public string? Phone { get; set; }
        public decimal? Score { get; set; }
        public string? Email { get; set; }
        public decimal? ExamId { get; set; }

        public virtual ExamInfo? Exam { get; set; }
        public virtual UserInfo? User { get; set; }
        public virtual ICollection<Complement> Complements { get; set; }
    }
}
