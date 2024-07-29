using System;
using System.Collections.Generic;

namespace Exam_Guardian.core.Data
{
    public partial class ExamProviderAction
    {
        public ExamProviderAction()
        {
            ExamProviderLinks = new HashSet<ExamProviderLink>();
        }

        public string? ActionName { get; set; }
        public decimal ExamProviderActionId { get; set; }

        public virtual ICollection<ExamProviderLink> ExamProviderLinks { get; set; }
    }
}
