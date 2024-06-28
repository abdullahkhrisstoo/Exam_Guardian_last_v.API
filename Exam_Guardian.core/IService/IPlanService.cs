using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.IService
{
    public interface IPlanService
    {
        Task CreatePlan(CreatePlanViewModel createPlanViewModel);
        Task DeletePlan(int id);
        Task UpdatePlan(UpdatePlanViewModel updatePlanViewModel);
        Task<PlanViewModel> GetPlanById(int id);
        Task<IEnumerable<PlanViewModel>> GetAllPlans();
        Task<IEnumerable<PlanFeature>> GetPlanFeaturesByPlanId(int planId);
        Task<Plan> GetPlanByExamBroviderId(int examproviderId);
    }
}
