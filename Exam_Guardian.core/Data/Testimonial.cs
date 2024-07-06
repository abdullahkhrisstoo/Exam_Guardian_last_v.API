using System;
using System.Collections.Generic;

namespace Exam_Guardian.core.Data
{
    public partial class Testimonial
    {
        public decimal Testimonialid { get; set; }
        public decimal? Testimonalstateid { get; set; }
        public decimal? Userid { get; set; }
        public string? Testimonialtext { get; set; }
        public DateTime? Createdat { get; set; }
        public DateTime? Updatedat { get; set; }

        public virtual Testimonalstate? Testimonalstate { get; set; }
        public virtual UserInfo? User { get; set; }
    }
}
