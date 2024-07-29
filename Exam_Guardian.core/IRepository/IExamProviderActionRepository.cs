using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.IRepository
{
    public interface IExamProviderActionRepository
    {
        Task<int> CreateExamProviderAction(CreateExamProviderActionDTO createComplementViewModel);
        Task<int> DeleteExamProviderAction(int id);
        Task<int> UpdateExamProviderAction(UpdateExamProviderActionDTO updateComplementViewModel);
        Task<ExamProviderActionDTO> GetExamProviderActionById(int id);
        Task<IEnumerable<ExamProviderActionDTO>> GetAllExamProviderActions();

    }
}
