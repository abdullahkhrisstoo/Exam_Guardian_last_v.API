using System;
using System.Collections.Generic;

namespace Exam_Guardian.core.Data
{
    public partial class ContactU
    {
        public decimal ContactId { get; set; }
        public string? Name { get; set; }
        public string? Message { get; set; }
        public string? Subject { get; set; }
        public string? Email { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
