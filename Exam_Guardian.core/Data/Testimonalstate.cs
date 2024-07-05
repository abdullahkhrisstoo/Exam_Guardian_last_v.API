using System;
using System.Collections.Generic;

namespace Exam_Guardian.core.Data
{
    public partial class Testimonalstate
    {
        public Testimonalstate()
        {
            Testimonials = new HashSet<Testimonial>();
        }

        public decimal Testimonalstateid { get; set; }
        public string? Testimonalstate1 { get; set; }

        public virtual ICollection<Testimonial> Testimonials { get; set; }
    }
}
