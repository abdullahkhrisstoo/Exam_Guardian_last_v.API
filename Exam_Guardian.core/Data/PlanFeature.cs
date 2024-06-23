using System;
using System.Collections.Generic;

namespace Exam_Guardian.core.Data
{
    public partial class PlanFeature
    {
        public decimal PlanFeatureId { get; set; }
        public string? FeaturesName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public decimal? PlanId { get; set; }

        public virtual Plan? Plan { get; set; }
    }
}
