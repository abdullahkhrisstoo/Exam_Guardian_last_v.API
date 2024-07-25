using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.DTO
{
    public class TestimonialWithExamProviderDTO
    {
        public decimal Testimonialid { get; set; }
        public decimal? Testimonalstateid { get; set; }
        public string? TestimonailState { get; set; }
        public string? Testimonialtext { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public decimal? ExamProviderId { get; set; }
        public string? ExamProviderName { get; set; }
        public string? ExamProviderImage { get; set; }
        public string? ExamProviderOwnerName { get; set; }
        
    }
}
