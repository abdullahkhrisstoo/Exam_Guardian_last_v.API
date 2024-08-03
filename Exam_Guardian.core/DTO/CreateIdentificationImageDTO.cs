using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.DTO
{
    public class CreateIdentificationImageDTO
    {
        public string? PathImageBack { get; set; }
        public string? PathImageFront { get; set; }
        public IFormFile ImageBack { get; set; }
        public IFormFile ImageFront { get; set; }
        public decimal? ExamReservationId { get; set; }
    }

}
