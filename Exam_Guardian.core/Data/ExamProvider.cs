﻿using System;
using System.Collections.Generic;

namespace Exam_Guardian.core.Data
{
    public partial class ExamProvider
    {
        public ExamProvider()
        {
            ExamInfos = new HashSet<ExamInfo>();
        }

        public decimal ExamProviderId { get; set; }
        public string? ExamProviderUniqueKey { get; set; }
        public decimal? PlanId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public decimal? UserId { get; set; }
        public string? CommercialRecordImg { get; set; }
        public string? Image { get; set; }

        public virtual Plan? Plan { get; set; }
        public virtual UserInfo? User { get; set; }
        public virtual Testimonial? Testimonial { get; set; }
        public virtual ICollection<ExamInfo> ExamInfos { get; set; }
    }
}
