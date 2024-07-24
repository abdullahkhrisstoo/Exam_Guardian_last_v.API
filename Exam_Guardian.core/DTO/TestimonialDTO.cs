using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.DTO
{
    public class TestimonialDTO
    {
        public decimal TestimonialId { get; set; }
        public decimal? TestimonalStateId { get; set; }
        public string? TestimonialState { get; set; }
        public string? TestimonialText { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public decimal? ExamProviderId { get; set; }
    }
}
