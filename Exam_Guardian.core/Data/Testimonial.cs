using System;
using System.Collections.Generic;

namespace Exam_Guardian.core.Data
{
    public partial class Testimonial
    {
        public decimal TestimonialId { get; set; }
        public decimal? TestimonialStateId { get; set; }
        public decimal? ExamProviderId { get; set; }
        public string? TestimonialText { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ExamProvider? ExamProvider { get; set; }
        public virtual TestimonialState? TestimonialState { get; set; }
    }
}
