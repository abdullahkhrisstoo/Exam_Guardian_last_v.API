﻿using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.IRepository
{
    public interface IExamProviderRepository
    {
        Task<List<ExamProvider>> GetAllExamProviders();
        Task<List<ExamProvider>> GetExamProvidersByStateId(int StateId);
        Task<List<ExamProvider>> GetExamProvidersByPlanId(int planId);
        Task<ExamProvider> GetExamProvidersById(int id);
        Task<ExamProvider> GetExamProvidersByUserId(int id);

        Task<List<ExamProvider>> GetTopExamProvider(int count);
        Task<ExamProvider> CreateExamProvider(ExamProviderDto examProviderDto); 



    }
}
