using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.DTO
{
    public class SendEmailViewModel
    {
        public string? Receiver { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
        public bool IsHtml { get; set; }
        public string? AttachmentPath { get; set; }

    }
}
