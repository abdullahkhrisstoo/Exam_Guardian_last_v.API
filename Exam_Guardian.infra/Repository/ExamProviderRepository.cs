using Exam_Guardian.core.Data;
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
                        .Include(p => p.Plan).ThenInclude(p => p.PlanFeatures)
                        .Include(exam => exam.ExamInfos);
        }
        public async Task<List<ExamProviderDTO>> GetAllExamProviders()
        {

            return await _modelContext.ExamProviders.Include(info => info.User).Select(e => new ExamProviderDTO
            {
                ExamProviderId = e.ExamProviderId,
                PlanId = e.PlanId,
                CreatedAt = e.CreatedAt,
                Image = e.Image,
                ExamProviderName = e.User.FirstName,
                State = e.User.State != null ? e.User.State.StatusName : "PENDING",
                UserId=e.User.UserId,
                ExamProviderEmail=e.User.Credential.Email
            }).ToListAsync();

        }


        public async Task<ExamProviderDTO> GetAllExamProviderByExamProviderName(string name)
        {

            return await _modelContext.ExamProviders.Include(info => info.User).Select(e => new ExamProviderDTO
            {
                ExamProviderId = e.ExamProviderId,
                PlanId = e.PlanId,
                CreatedAt = e.CreatedAt,
                Image = e.Image,
                ExamProviderUniqueKey = e.ExamProviderUniqueKey,
                ExamProviderName = e.User.FirstName,
                State = e.User.State != null ? e.User.State.StatusName : "Waiting"
            }).Where(e => e.ExamProviderName == name).FirstOrDefaultAsync();

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

        public async Task<GetExamProviderByUserIdDto> GetExamProvidersByUserId(int id)
        {
            try
            {
                var examProvider = await IncludeDependencies(_modelContext.ExamProviders)
                                          .Where(ep => ep.User.UserId == id)
                                          .SingleOrDefaultAsync();

                if (examProvider == null)
                {
                    return null;
                }

                var dto = new GetExamProviderByUserIdDto
                {
                    ExamProviderId = examProvider.ExamProviderId,
                    ExamProviderUniqueKey = examProvider.ExamProviderUniqueKey!,
                    PlanId = examProvider.Plan.PlanId,
                    UserId = examProvider.UserId??0,
                    CommercialRecordImg = examProvider.CommercialRecordImg,
                    Image = examProvider!.Image!,
                    Plan = new PlanDto
                    {
                        PlanId = examProvider.Plan.PlanId,
                        PlanName = examProvider.Plan.PlanName,
                        PlanDescription = examProvider.Plan.PlanDescription,
                        PlanPrice = examProvider.Plan.PlanPrice??0,
                        PlanFeatures = examProvider.Plan.PlanFeatures
                                                    .Select(pf => new PlanFeatureDto
                                                    {
                                                        PlanFeatureId = pf.PlanFeatureId,
                                                        FeaturesName = pf.FeaturesName
                                                    }).ToList()
                    }
                };

                return dto;
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
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
        public async Task<ExamProvider> UpdateExamProvider(UpdateExamProviderDTO examProviderDto)
        {


            var examProvider = new ExamProvider
            {
                ExamProviderId = examProviderDto.ExamProviderId,
                ExamProviderUniqueKey = examProviderDto.ExamProviderUniqueKey,
                PlanId = examProviderDto.PlanId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                UserId = examProviderDto.UserId,
                CommercialRecordImg = examProviderDto.CommercialRecordImg,
                Image = examProviderDto.Image
            };

            _modelContext.ExamProviders.Update(examProvider);
            await _modelContext.SaveChangesAsync();
            return examProvider;


        }
        public async Task<int> UpdateExamProviderState(UpdateExamProviderStateDTO updateExamProviderStateDTO) {

          var examProvider= (await _modelContext.ExamProviders.Include(e => e.User).
                FirstOrDefaultAsync(e => e.ExamProviderId == updateExamProviderStateDTO.ExamProviderId));
            if (examProvider is null || examProvider.User is null) {
                throw new Exception("user not found");
            }
            examProvider.User.StateId = updateExamProviderStateDTO.StateId;
            return await _modelContext.SaveChangesAsync();
        }
        public async Task<ExamProvider> CreateExamProvider(CreateExamProviderDTO examProviderDto)
        {
            try
            {
                examProviderDto.ExamProviderUniqueKey= Guid.NewGuid().ToString();
                var examProvider = new ExamProvider
                {
                    ExamProviderUniqueKey = examProviderDto.ExamProviderUniqueKey/*?.Encrypt()*/,
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
    

