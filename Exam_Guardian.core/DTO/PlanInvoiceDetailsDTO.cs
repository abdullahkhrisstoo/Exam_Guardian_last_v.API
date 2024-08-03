using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.DTO
{
    public class PlanInvoiceDetailsDTO
    {
        public string? PlanName { get; set; }
        public string? ExamProviderName { get; set; }
        public decimal? Value { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
