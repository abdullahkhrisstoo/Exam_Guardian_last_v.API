using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.DTO
{
    public class UpdateExamInfoDTO
    {
        public decimal ExamId { get; set; }
        public string? ExamTitle { get; set; }
        public string? ExamImage { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public decimal? ExamProviderId { get; set; }
        public decimal? Price { get; set; }
    }
}
