using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.DTO
{
    public class GetAvailableTime
    {
        public int Duration { get; set; }
        public DateTime DTime { get; set; }
        public string? Type { get; set; }
    }
}
