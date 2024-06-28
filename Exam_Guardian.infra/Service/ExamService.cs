using Exam_Guardian.core.Data;
using Exam_Guardian.core.IRepository;
using Exam_Guardian.core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.infra.Service
{
    public class ExamService : IExamService
    {
        private readonly IExamProviderRepository _examProviderRepository;

        public ExamService(IExamProviderRepository examProviderRepository) {
            _examProviderRepository = examProviderRepository;
        }

        public Task<List<ExamProvider>> GetAllExamProviders()
        {
            return _examProviderRepository.GetAllExamProviders();
        }

        public Task<ExamProvider> GetExamProvidersById(int id)
        {
            return _examProviderRepository.GetExamProvidersById(id);
        }

        public Task<List<ExamProvider>> GetExamProvidersByPlanId(int planId)
        {
            return _examProviderRepository.GetExamProvidersByPlanId(planId);
        }

        public Task<List<ExamProvider>> GetExamProvidersByStateId(int StateId)
        {
            return _examProviderRepository.GetExamProvidersByStateId(StateId);
        }
    }
}
