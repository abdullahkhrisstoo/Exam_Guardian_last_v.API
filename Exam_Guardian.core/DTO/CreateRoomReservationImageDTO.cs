using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.DTO
{
    public class CreateRoomReservationImageDTO
    {
        public string? Place { get; set; }
        public decimal? ExamReservationId { get; set; }
        public string? Path { get; set; }
        public IFormFile? Image{ get; set; }
    }

}
