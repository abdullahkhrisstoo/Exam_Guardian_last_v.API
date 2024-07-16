using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.DTO
{
    public class StatisticsViewModel
    {
        public int TestimonialApprovedCount { get; set; }
        public int TestimonialRejectedCount { get; set; }
        public int TestimonialPendingCount { get; set; }
        public int AllTestimonialCount { get; set; }
        //
        public int ExamProviderApprovedCount { get; set; }
        public int ExamProviderRejectedCount { get; set; }
        public int ExamProviderPendingCount { get; set; }
        public int AllExamProviderCount { get; set; }
        //

        public int AllProctorCount { get; set; }
        public int AllStudentCount { get; set; }


    }



}
  
