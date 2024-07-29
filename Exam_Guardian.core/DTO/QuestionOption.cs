using System;
using System.Collections.Generic;
namespace Exam_Guardian.core.DTO
{
    public partial class QuestionOption
    {
        public decimal OptionId { get; set; }
        public string? Title { get; set; }
        public string? IsCorrect { get; set; }
        public decimal? QuestionId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Question? Question { get; set; }
    }
}
