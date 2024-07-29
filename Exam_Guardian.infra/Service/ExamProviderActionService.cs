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
    public class ExamProviderActionService : IExamProviderActionService
    {
        private readonly IExamProviderActionRepository _repository;

        public ExamProviderActionService(IExamProviderActionRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateExamProviderAction(CreateExamProviderActionDTO createDto)
        {
            return await _repository.CreateExamProviderAction(createDto);
        }

        public async Task<int> DeleteExamProviderAction(int id)
        {
            return await _repository.DeleteExamProviderAction(id);
        }

        public async Task<int> UpdateExamProviderAction(UpdateExamProviderActionDTO updateDto)
        {
            return await _repository.UpdateExamProviderAction(updateDto);
        }

        public async Task<ExamProviderActionDTO> GetExamProviderActionById(int id)
        {
            return await _repository.GetExamProviderActionById(id);
        }

        public async Task<IEnumerable<ExamProviderActionDTO>> GetAllExamProviderActions()
        {
            return await _repository.GetAllExamProviderActions();
        }
    }

}
