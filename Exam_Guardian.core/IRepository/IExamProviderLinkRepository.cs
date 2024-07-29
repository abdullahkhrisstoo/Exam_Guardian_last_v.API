using Exam_Guardian.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.IRepository
{
    public interface IExamProviderLinkRepository
    {
        Task<int> CreateExamProviderLink(CreateExamProviderLinkDTO createComplementViewModel);
        Task<int> DeleteExamProviderLink(int id);
        Task<int> UpdateExamProviderLink(UpdateExamProviderLinkDTO updateComplementViewModel);
        Task<ExamProviderLinkDTO> GetExamProviderLinkById(int id);
        Task<IEnumerable<ExamProviderLinkDTO>> GetAllExamProviderLinks();
        Task<IEnumerable<ExamProviderLinkDTO>> GetExamProviderLinkByCompanyAndActionName(string companyName,string actionName);
        Task<IEnumerable<ExamProviderLinkDTO>> GetExamProviderLinkByCompany(string companyName);
    }
}
