using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.DTO
{
    public class UpdateComplementDTO
    {
        public decimal ComplementId { get; set; }
        public string? ProctorDesc { get; set; }
        public string? StudentDesc { get; set; }
        public decimal? ExamReservationId { get; set; }
    }
}
