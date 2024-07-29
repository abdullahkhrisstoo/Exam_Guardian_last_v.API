using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.DTO
{
    public class ExamReservationPaymentDTO
    {
        public int UserId { get; set; }
        public string ExamName { get; set; }
        public CardInfoDTO CardInfoDTO { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime ReservationDate { get; set; } 
    }
}
