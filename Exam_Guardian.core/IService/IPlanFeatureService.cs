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
        Task<int> CreatePlanFeature(CreatePlanFeatureViewModel createPlanFeatureViewModel);
        Task<int> DeletePlanFeature(int id);
        Task<int> UpdatePlanFeature(UpdatePlanFeatureViewModel updatePlanFeatureViewModel);
        Task<PlanFeatureViewModel> GetPlanFeatureById(int id);
        Task<IEnumerable<PlanFeatureViewModel>> GetAllPlanFeatures();
    }
}
