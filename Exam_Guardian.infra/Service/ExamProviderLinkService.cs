using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IRepository;
using Exam_Guardian.core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.infra.Service
{
    public class ExamProviderLinkService : IExamProviderLinkService
    {
        private readonly IExamProviderLinkRepository _repository;

        public ExamProviderLinkService(IExamProviderLinkRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateExamProviderLink(CreateExamProviderLinkDTO createDto)
        {
            return await _repository.CreateExamProviderLink(createDto);
        }

        public async Task<int> DeleteExamProviderLink(int id)
        {
            return await _repository.DeleteExamProviderLink(id);
        }

        public async Task<int> UpdateExamProviderLink(UpdateExamProviderLinkDTO updateDto)
        {
            return await _repository.UpdateExamProviderLink(updateDto);
        }

        public async Task<ExamProviderLinkDTO> GetExamProviderLinkById(int id)
        {
            return await _repository.GetExamProviderLinkById(id);
        }

        public async Task<IEnumerable<ExamProviderLinkDTO>> GetAllExamProviderLinks()
        {
            return await _repository.GetAllExamProviderLinks();
        }

        public async Task<IEnumerable<ExamProviderLinkDTO>> GetExamProviderLinkByCompanyAndActionName(string companyName, string actionName)
        {
            return await _repository.GetExamProviderLinkByCompanyAndActionName(companyName, actionName);
        }

        public async Task<IEnumerable<ExamProviderLinkDTO>> GetExamProviderLinkByCompany(string companyName)
        {
            return await _repository.GetExamProviderLinkByCompany(companyName);
        }
    }

}
