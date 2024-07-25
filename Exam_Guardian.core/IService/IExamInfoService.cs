using Exam_Guardian.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.IService
{
    public interface IExamInfoService
    {
        Task<ExamInfoDTO> CreateExamAsync(CreateExamInfoDTO createExamDto);
        Task<ExamInfoDTO> GetExamByIdAsync(decimal examId);
        Task<bool> UpdateExamAsync(UpdateExamInfoDTO updateExamDto);
        Task<bool> DeleteExamAsync(decimal examId);
        Task<IEnumerable<ExamInfoDTO>> GetExamsByExamProviderIdAsync(decimal examProviderId);
        Task<IEnumerable<ExamInfoDTO>> GetAllExams();
    }
}
