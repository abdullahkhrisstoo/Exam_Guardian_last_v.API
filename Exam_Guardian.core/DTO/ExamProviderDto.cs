using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.DTO
{
    public class ExamProviderDto
    {
        public string? ExamProviderUniqueKey { get; set; }
        public decimal? PlanId { get; set; }
        public decimal? UserId { get; set; }
        public string? CommercialRecordImg { get; set; }
        public string? Image { get; set; }
    }
}
