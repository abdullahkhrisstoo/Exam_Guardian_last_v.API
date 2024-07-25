using System;
using System.Collections.Generic;

namespace Exam_Guardian.core.DTO
{
    public partial class ExamInfoDTO
    {


        public decimal ExamId { get; set; }
        public string? ExamTitle { get; set; }
        public string? ExamImage { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public decimal? ExamProviderId { get; set; }

    }
}
