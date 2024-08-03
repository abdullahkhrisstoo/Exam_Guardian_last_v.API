using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.IRepo
{
    public interface IPlanRepository
    {
        Task<int> CreatePlan(CreatePlanDTO createPlanViewModel);
        Task<int> DeletePlan(int id);
        Task<int> UpdatePlan(UpdatePlanDTO updatePlanViewModel);
        Task<PlanDTO> GetPlanById(decimal id);
        Task<IEnumerable<PlanDTO>> GetAllPlans();
        Task<IEnumerable<PlanFeature>> GetPlanFeaturesByPlanId(int planId);
        Task<PlanDTO?> GetPlanByExamProviderId(decimal examproviderId);
        Task<List<Plan>> GetAllPlansWithFeatures();
        Task<Plan> GetPlanWithFeatures(decimal id);

    }

}
