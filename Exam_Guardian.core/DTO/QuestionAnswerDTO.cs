using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.DTO
{
    public class QuestionAnswerDTO
    {
        public int QuestionId { get; set; }
        public int SelectedAnswer { get; set; }
    }

    public class QuestionCorrectionAnswerListDTO
    {
        public List<QuestionAnswerDTO> QuestionAnswers { get; set; }
    }

}
