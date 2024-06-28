using System;
using System.Collections.Generic;

namespace Exam_Guardian.core.Data
{
    public partial class Testimonial
    {
        public decimal TestimonialId { get; set; }
        public decimal? UserId { get; set; }
        public string? TestimonialText { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual UserInfo? User { get; set; }
    }
}
