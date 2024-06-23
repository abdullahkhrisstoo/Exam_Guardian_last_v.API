using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.DTO
{
    public class UpdatePasswordViewModel
    {
        public decimal CredentialId { get; set; }
        public string? LastPassword { get; set; }
        public string? NewPassword { get; set; }
        public string? ConfirmPassword { get; set; }






    }
}
