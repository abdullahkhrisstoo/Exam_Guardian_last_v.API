using Exam_Guardian.core.DTO;

namespace Exam_Guardian.API.ResponseHandler
{
    public class ExamResponse
    {
        public bool Success { get; set; }
        public List<Exam> Data { get; set; }
    }
}
