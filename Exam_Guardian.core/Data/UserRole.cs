using System;
using System.Collections.Generic;

namespace Exam_Guardian.core.Data
{
    public partial class UserRole
    {
        public UserRole()
        {
            UserInfos = new HashSet<UserInfo>();
        }

        public decimal RoleId { get; set; }
        public string? RoleName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<UserInfo> UserInfos { get; set; }
    }
}
