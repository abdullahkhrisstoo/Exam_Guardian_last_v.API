using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.DTO
{
    public class UpdateRoomReservationImageDTO
    {
        public decimal RoomReservationImageId { get; set; }
        public string? Place { get; set; }
        public decimal? ExamReservationId { get; set; }
        public string? Path { get; set; }
    }

}
