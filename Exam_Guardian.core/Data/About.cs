using System;
using System.Collections.Generic;

namespace Exam_Guardian.core.Data
{
    public partial class About
    {
        public About()
        {
            Aboutpoints = new HashSet<Aboutpoint>();
        }

        public decimal AboutId { get; set; }
        public string Title { get; set; } = null!;

        public virtual ICollection<Aboutpoint> Aboutpoints { get; set; }
    }
}
