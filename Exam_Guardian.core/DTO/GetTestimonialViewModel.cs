using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.DTO
{
    public class GetTestimonialViewModel
    {
        public decimal Testimonialid { get; set; }
        public decimal? Testimonalstateid { get; set; }
        public decimal? Userid { get; set; }
        public string? Testimonialtext { get; set; }
        public DateTime? Createdat { get; set; }
        public DateTime? Updatedat { get; set; }
        public decimal ExamProviderId { get; set; }
        public string? Image { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
