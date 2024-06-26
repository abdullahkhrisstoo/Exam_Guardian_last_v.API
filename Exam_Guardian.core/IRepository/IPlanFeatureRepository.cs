﻿using Exam_Guardian.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.IRepository
{
    public interface IPlanFeatureRepository
    {
        Task CreatePlanFeature(CreatePlanFeatureViewModel createPlanFeatureViewModel);
        Task DeletePlanFeature(int id);
        Task UpdatePlanFeature(UpdatePlanFeatureViewModel updatePlanFeatureViewModel);
        Task<PlanFeatureViewModel> GetPlanFeatureById(int id);
        Task<IEnumerable<PlanFeatureViewModel>> GetAllPlanFeatures();
    }
}
