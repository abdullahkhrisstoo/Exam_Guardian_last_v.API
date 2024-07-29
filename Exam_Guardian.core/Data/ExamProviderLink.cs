using System;
using System.Collections.Generic;

namespace Exam_Guardian.core.Data
{
    public partial class ExamProviderLink
    {
        public string? LinkPath { get; set; }
        public decimal? ExamProviderId { get; set; }
        public decimal? ActionId { get; set; }
        public decimal ExamProviderLinkId { get; set; }

        public virtual ExamProviderAction? Action { get; set; }
        public virtual ExamProvider? ExamProvider { get; set; }
    }
}
