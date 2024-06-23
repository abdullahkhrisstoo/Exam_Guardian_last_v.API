using System;
using System.Collections.Generic;

namespace Exam_Guardian.core.Data
{
    public partial class UserState
    {
        public UserState()
        {
            UserInfos = new HashSet<UserInfo>();
        }

        public decimal StateId { get; set; }
        public string? StatusName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<UserInfo> UserInfos { get; set; }
    }
}
