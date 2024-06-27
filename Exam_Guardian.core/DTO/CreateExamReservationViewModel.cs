using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.DTO
{
    public class CreateExamReservationViewModel
    {
        public string StudentTokenEmail { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ProctorTokenEmail { get; set; }
        public string UniqueKey { get; set; }
        public int UserId { get; set; }
        public string StudentName { get; set; }
        public string Phone { get; set; }
        public int score { get; set; }
        public string Email { get; set; }
        public int EXAM_PROVIDER_ID { get; set; }

    }

}
