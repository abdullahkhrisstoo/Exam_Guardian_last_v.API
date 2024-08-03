using System;
using System.Collections.Generic;

namespace Exam_Guardian.core.Data
{
    public partial class PlanInvoice
    {
        public decimal PlanInvoiceId { get; set; }
        public decimal? Value { get; set; }
        public decimal? PlanId { get; set; }
        public decimal? ExamProviderId { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual ExamProvider? ExamProvider { get; set; }
        public virtual Plan? Plan { get; set; }
    }
}
