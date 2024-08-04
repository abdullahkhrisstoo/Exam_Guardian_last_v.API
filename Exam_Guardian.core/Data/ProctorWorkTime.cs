using System;
using System.Collections.Generic;

namespace Exam_Guardian.core.Data
{
    public partial class ProctorWorkTime
    {
        public decimal ProctorWorkTimesId { get; set; }
        public string? WorkFrom { get; set; }
        public string? WorkTo { get; set; }
    }
}