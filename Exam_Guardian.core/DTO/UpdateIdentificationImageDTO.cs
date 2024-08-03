using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.DTO
{
    public class UpdateIdentificationImageDTO
    {
        public decimal IdentificationImageId { get; set; }
        public string? PathImageBack { get; set; }
        public string? PathImageFront { get; set; }
        public decimal? ExamReservationId { get; set; }
    }

}
