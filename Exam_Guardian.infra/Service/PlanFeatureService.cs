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
    public class PlanFeatureService : IPlanFeatureService
    {
        private readonly IPlanFeatureRepository _planFeatureRepository;

        public PlanFeatureService(IPlanFeatureRepository planFeatureRepository)
        {
            _planFeatureRepository = planFeatureRepository;
        }

        public async Task<int> CreatePlanFeature(CreatePlanFeatureViewModel createPlanFeatureViewModel)
        {
           return await _planFeatureRepository.CreatePlanFeature(createPlanFeatureViewModel);
        }

        public async Task<int> DeletePlanFeature(int id)
        {
            return await _planFeatureRepository.DeletePlanFeature(id);
        }

        public async Task<int> UpdatePlanFeature(UpdatePlanFeatureViewModel updatePlanFeatureViewModel)
        {
           return await _planFeatureRepository.UpdatePlanFeature(updatePlanFeatureViewModel);
        }

        public async Task<PlanFeatureViewModel> GetPlanFeatureById(int id)
        {
            return await _planFeatureRepository.GetPlanFeatureById(id);
        }

        public async Task<IEnumerable<PlanFeatureViewModel>> GetAllPlanFeatures()
        {
            return await _planFeatureRepository.GetAllPlanFeatures();
        }
    }

}
