using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.DTO
{
    public class ExamReservationPaymentDTO
    {
        public decimal UserId { get; set; }
        public string StudentEmail { get; set; }
        public string StudentName { get; set; }
        public string ExamName { get; set; }
        public int ExamDuration { get; set; }
        public decimal Price{ get; set; }
        public CardInfoDTO CardInfoDTO { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime ReservationDate { get; set; } 
    }
}
