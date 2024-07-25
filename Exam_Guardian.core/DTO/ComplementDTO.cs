
namespace Exam_Guardian.core.DTO
{

    public class ComplementDTO
    {
        public decimal ComplementId { get; set; }
        public string? ProctorDesc { get; set; }
        public string? StudentDesc { get; set; }
        public decimal? ExamReservationId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
