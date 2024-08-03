using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.DTO
{
    public class UpdatePlanInvoiceDTO
    {
        public decimal PlanInvoiceId { get; set; }
        public decimal? Value { get; set; }
        public decimal? PlanId { get; set; }
        public decimal? ExamProviderId { get; set; }
    }

}
