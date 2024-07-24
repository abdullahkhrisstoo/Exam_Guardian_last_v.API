using Exam_Guardian.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.IService
{
    public interface IPlanFeatureService
    {
        Task<int> CreatePlanFeature(CreatePlanFeatureDTO createPlanFeatureViewModel);
        Task<int> DeletePlanFeature(int id);
        Task<int> UpdatePlanFeature(UpdatePlanFeatureDTO updatePlanFeatureViewModel);
        Task<PlanFeatureDTO> GetPlanFeatureById(int id);
        Task<IEnumerable<PlanFeatureDTO>> GetAllPlanFeatures();
        Task<IEnumerable<PlanFeatureDTO>> GetPlanFeaturesByPlanId(decimal planId);
    }
}
