using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.DTO
{
    public class UpdateExamProviderLinkDTO
    {
        public decimal ExamProviderLinkId { get; set; }
        public string? LinkPath { get; set; }
        public decimal? ExamProviderId { get; set; }
        public decimal? ActionId { get; set; }
    }
}
