using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.DTO
{
    public class CreateTestimonailDTO
    {
       
        public decimal? TestimonialStateId { get; set; }
        public string? TestimonialText { get; set; }
        public decimal? ExamProviderId { get; set; }

    }
}
