namespace Exam_Guardian.core.DTO
{
    public class TimeSlotsViewModel
    {
        public int ProctorCount { get; set; }
        public int ReservationCount { get; set; }
        public string? SartDate { get; set; }
        public string? EndDate { get; set; }
    }


    public class UnavailableTimeViewModel
    {
        public string SartDate { get; set; }
        public string EndDate { get; set; }
    }
}
