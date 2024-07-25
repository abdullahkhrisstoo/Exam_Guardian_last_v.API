using System;
using System.Collections.Generic;

namespace Exam_Guardian.core.Data
{
    public partial class TestimonialState
    {
        public TestimonialState()
        {
            Testimonials = new HashSet<Testimonial>();
        }

        public decimal TestimonialStateId { get; set; }
        public string? TestimonialStateText { get; set; }

        public virtual ICollection<Testimonial> Testimonials { get; set; }
    }
}
