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

        public async Task<int> CreatePlanFeature(CreatePlanFeatureDTO createPlanFeatureViewModel)
        {
            return await _planFeatureRepository.CreatePlanFeature(createPlanFeatureViewModel);
        }

        public async Task<int> DeletePlanFeature(int id)
        {
            return await _planFeatureRepository.DeletePlanFeature(id);
        }

        public async Task<int> UpdatePlanFeature(UpdatePlanFeatureDTO updatePlanFeatureViewModel)
        {
            return await _planFeatureRepository.UpdatePlanFeature(updatePlanFeatureViewModel);
        }

        public async Task<PlanFeatureDTO> GetPlanFeatureById(int id)
        {
            return await _planFeatureRepository.GetPlanFeatureById(id);
        }

        public async Task<IEnumerable<PlanFeatureDTO>> GetAllPlanFeatures()
        {
            return await _planFeatureRepository.GetAllPlanFeatures();
        }

        public async Task<IEnumerable<PlanFeatureDTO>> GetPlanFeaturesByPlanId(decimal planId)
        {
            return await _planFeatureRepository.GetPlanFeaturesByPlanId(planId);
        }
    }

}
