using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.DTO
{
    public class UserDataViewModel
    {
        public decimal? UserId { get; set; }
        public decimal? CredentialId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public decimal? StateId { get; set; }
        public string? Email { get; set; }
        public string? Phonenum { get; set; }
        public decimal? RoleId { get; set; }

    }
}
