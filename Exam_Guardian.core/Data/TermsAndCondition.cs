using System;
using System.Collections.Generic;

namespace Exam_Guardian.core.Data
{
    public partial class TermsAndCondition
    {
        public decimal TermsId { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
