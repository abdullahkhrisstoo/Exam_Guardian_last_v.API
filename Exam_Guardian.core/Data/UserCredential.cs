using System;
using System.Collections.Generic;

namespace Exam_Guardian.core.Data
{
    public partial class UserCredential
    {
        public UserCredential()
        {
            UserInfos = new HashSet<UserInfo>();
        }

        public decimal CredentialId { get; set; }
        public string? Email { get; set; }
        public string? Phonenum { get; set; }
        public string? Password { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<UserInfo> UserInfos { get; set; }
    }
}
