using System;
using System.Collections.Generic;

namespace Exam_Guardian.core.Data
{
    public partial class Plan
    {
        public Plan()
        {
            ExamProviders = new HashSet<ExamProvider>();
            PlanFeatures = new HashSet<PlanFeature>();
            PlanInvoices = new HashSet<PlanInvoice>();
        }

        public decimal PlanId { get; set; }
        public string? PlanName { get; set; }
        public string? PlanDescription { get; set; }
        public decimal? PlanPrice { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<ExamProvider> ExamProviders { get; set; }
        public virtual ICollection<PlanFeature> PlanFeatures { get; set; }
        public virtual ICollection<PlanInvoice> PlanInvoices { get; set; }
    }
}
