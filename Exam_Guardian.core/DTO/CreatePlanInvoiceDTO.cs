using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.DTO
{
    public class CreatePlanInvoiceDTO
    {
        public decimal? Value { get; set; }
        public decimal? PlanId { get; set; }
        public decimal? ExamProviderId { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

}
