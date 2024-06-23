using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.DTO
{
    public class UpdatePlanFeatureViewModel
    {
        public int PlanFeatureId { get; set; }
        public string FeaturesName { get; set; }
        public int PlanId { get; set; }
    }
}
