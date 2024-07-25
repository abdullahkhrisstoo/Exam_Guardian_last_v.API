using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.DTO
{
    public class UpdatePlanDTO
    {
        public decimal PlanId { get; set; }
        public string? PlanName { get; set; }
        public string? PlanDescription { get; set; }
        public decimal? PlanPrice { get; set; }
    }
}
