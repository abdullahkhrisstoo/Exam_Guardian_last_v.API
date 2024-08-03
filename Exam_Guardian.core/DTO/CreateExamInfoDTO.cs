using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.DTO
{
    public class CreateExamInfoDTO
    {

        public string? ExamTitle { get; set; }
        public string? ExamImage { get; set; }

        public decimal? ExamProviderId { get; set; }
        public decimal? Price { get; set; }
    }
}
