using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.DTO
{
    public class UpdateComplementViewModel
    {
        public int ComplementId { get; set; }
        public string ProctorDesc { get; set; }
        public string StudentDesc { get; set; }
        public int ExamReservationId { get; set; }
    }
}
