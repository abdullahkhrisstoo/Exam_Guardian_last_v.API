﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.DTO
{
    public class UpdatePlanFeatureDTO
    {
        public decimal PlanFeatureId { get; set; }
        public string? FeaturesName { get; set; }
        public decimal? PlanId { get; set; }
    }
}
