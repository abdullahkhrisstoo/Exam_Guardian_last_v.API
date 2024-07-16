﻿using Exam_Guardian.core.Data;
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
        Task <int> CreatePlan(CreatePlanViewModel createPlanViewModel);
        Task <int> DeletePlan(int id);
        Task <int> UpdatePlan(UpdatePlanViewModel updatePlanViewModel);
        Task<PlanViewModel> GetPlanById(int id);
        Task<IEnumerable<PlanViewModel>> GetAllPlans();
        Task<IEnumerable<PlanFeature>> GetPlanFeaturesByPlanId(int planId);
        Task<Plan> GetPlanByExamBroviderId(int examproviderId);
        Task<List<Plan>> GetAllPlansWithFeatures();
        Task<Plan> GetPlanWithFeatures(decimal id);

    }

}
