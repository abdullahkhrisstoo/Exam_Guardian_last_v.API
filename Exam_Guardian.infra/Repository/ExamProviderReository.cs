﻿using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IRepository;
using Exam_Guardian.infra.Utilities.States;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam_Guardian.infra.Repository
{
    public class ExamProviderRepository : IExamProviderRepository
    {
        private readonly ModelContext _modelContext;

        public ExamProviderRepository(ModelContext modelContext)
        {
            _modelContext = modelContext ?? throw new ArgumentNullException(nameof(modelContext));
        }

        private IQueryable<ExamProvider> IncludeDependencies(IQueryable<ExamProvider> query)
        {
            return query.Include(info => info.User)
                        .Include(p => p.Plan)
                        .Include(planFet => planFet.Plan.PlanFeatures)
                        .Include(exam => exam.ExamInfos);
        }

        public async Task<List<ExamProvider>> GetAllExamProviders()
        {
            try
            {
                return await IncludeDependencies(_modelContext.ExamProviders).ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<ExamProvider> GetExamProvidersById(int id)
        {
            try
            {
                return await IncludeDependencies(_modelContext.ExamProviders)
                             .SingleOrDefaultAsync(check => check.ExamProviderId == id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<ExamProvider>> GetExamProvidersByPlanId(int planId)
        {
            try
            {
                return await IncludeDependencies(_modelContext.ExamProviders)
                             .Where(check => check.Plan.PlanId == planId)
                             .ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<ExamProvider>> GetExamProvidersByStateId(int stateId)
        {
            try
            {
                return await IncludeDependencies(_modelContext.ExamProviders)
                             .Where(check => check.User.StateId == stateId)
                             .ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<ExamProvider> GetExamProvidersByUserId(int id)
        {
            try
            {
                return await IncludeDependencies(_modelContext.ExamProviders)
                             .Where(check => check.User.UserId == id)
                             .SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<ExamProvider>> GetTopExamProvider(int count)
        {
            try
            {
                var totalProviders = await _modelContext.ExamProviders
                                                        .Where(check => check.User.StateId == UserStateConst.Approved)
                                                        .CountAsync();

                if (count > totalProviders)
                {

                    count = totalProviders;
                }

                return await IncludeDependencies(_modelContext.ExamProviders)
                             .Where(check => check.User.StateId == UserStateConst.Approved)
                             .Take(count)
                             .ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<ExamProvider> CreateExamProvider(ExamProviderDto examProviderDto)
        {
            try
            {
                var examProvider = new ExamProvider
                {
                    ExamProviderUniqueKey = examProviderDto.ExamProviderUniqueKey,
                    PlanId = examProviderDto.PlanId,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    UserId = examProviderDto.UserId,
                    CommercialRecordImg = examProviderDto.CommercialRecordImg,
                    Image = examProviderDto.Image
                };

                _modelContext.ExamProviders.Add(examProvider);
                await _modelContext.SaveChangesAsync();
                return examProvider;
            }
            catch (Exception ex)
            {
                // Log the exception
                throw;
            }
        }
    }
}
    

