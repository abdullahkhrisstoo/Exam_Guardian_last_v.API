﻿using Exam_Guardian.core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.IService
{
    public interface IExamService
    {
        Task<List<ExamProvider>> GetAllExamProviders();
        Task<List<ExamProvider>> GetExamProvidersByStateId(int StateId);
        Task<List<ExamProvider>> GetExamProvidersByPlanId(int planId);
        Task<ExamProvider> GetExamProvidersById(int id);
    }
}
