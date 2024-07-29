using System;
using System.Collections.Generic;

namespace Exam_Guardian.core.Data
{
    public partial class ExamInfo
    {
        public ExamInfo()
        {
            ExamReservations = new HashSet<ExamReservation>();
        }

        public decimal ExamId { get; set; }
        public string? ExamTitle { get; set; }
        public string? ExamImage { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public decimal? ExamProviderId { get; set; }
        public decimal? Price { get; set; }

        public virtual ExamProvider? ExamProvider { get; set; }
        public virtual ICollection<ExamReservation> ExamReservations { get; set; }
    }
}
