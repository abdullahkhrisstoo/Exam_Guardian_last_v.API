using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.DTO
{
    public class ExamProviderDTO
    {

        public decimal ExamProviderId { get; set; }
        public string? ExamProviderUniqueKey { get; set; }
        public decimal? PlanId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? ExamProviderName { get; set; }
        public decimal? UserId { get; set; }
        public string? CommercialRecordImg { get; set; }
        public string? Image { get; set; }
        public string? State { get; set; }
    }
}
