using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.DTO
{
    public class ExamReservationDetailsDTO
    {
        public string? StudentName { get; set; }
        public string? StudentEmail { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public decimal? Score { get; set; }
        public string? ExamName { get; set; }
        public decimal? Value { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
