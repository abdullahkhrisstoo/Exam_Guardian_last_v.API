using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.DTO
{
    public class UpdatePhoneViewModel
    {
        public decimal UserId { get; set; }
        public string? PhoneNo { get; set; }
        public string? Password { get; set; }
    }
}
