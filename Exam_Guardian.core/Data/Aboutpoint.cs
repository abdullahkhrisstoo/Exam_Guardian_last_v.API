using System;
using System.Collections.Generic;

namespace Exam_Guardian.core.Data
{
    public partial class Aboutpoint
    {
        public decimal AboutpointsId { get; set; }
        public decimal? AboutId { get; set; }
        public string Listitem { get; set; } = null!;

        public virtual About? About { get; set; }
    }
}
