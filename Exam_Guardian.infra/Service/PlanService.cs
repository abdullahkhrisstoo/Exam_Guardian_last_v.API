﻿using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IRepo;
using Exam_Guardian.core.IService;
using Exam_Guardian.infra.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.infra.Service
{
    public class PlanService : IPlanService
    {
        private readonly IPlanRepository _planRepository;

        public PlanService(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
        }

        public async Task<int> CreatePlan(CreatePlanDTO createPlanViewModel)
        {
            return await _planRepository.CreatePlan(createPlanViewModel);
        }

        public async Task<int> DeletePlan(int id)
        {
            return await _planRepository.DeletePlan(id);
        }

        public async Task<int> UpdatePlan(UpdatePlanDTO updatePlanViewModel)
        {
            return await _planRepository.UpdatePlan(updatePlanViewModel);
        }

        public async Task<PlanDTO> GetPlanById(decimal id)
        {
            return await _planRepository.GetPlanById(id);
        }

        public async Task<IEnumerable<PlanDTO>> GetAllPlans()
        {
            return await _planRepository.GetAllPlans();
        }

        public async Task<IEnumerable<PlanFeature>> GetPlanFeaturesByPlanId(int planId)
        {
            return await _planRepository.GetPlanFeaturesByPlanId(planId);
        }

        public async Task<PlanDTO?> GetPlanByExamProviderId(decimal examproviderId)
        {
            return await _planRepository.GetPlanByExamProviderId(examproviderId);
        }

        public async Task<List<Plan>> GetAllPlansWithFeatures()
        {
            return await _planRepository.GetAllPlansWithFeatures();
        }

        public async Task<Plan> GetPlanWithFeatures(decimal id)
        {
            return await _planRepository.GetPlanWithFeatures(id);
        }
    }


}
