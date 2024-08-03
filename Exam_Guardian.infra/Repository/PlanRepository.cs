using Dapper;
using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using Exam_Guardian.core.ICommon;
using Exam_Guardian.core.IRepo;
using Exam_Guardian.core.Mapper;
using Exam_Guardian.core.Utilities.PackagesConstants;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.infra.Repo
{
    public class PlanRepository : IPlanRepository
    {
        private readonly IDbContext _dbContext;
        private readonly ModelContext _modelContext;


        public PlanRepository(IDbContext dbContext, ModelContext modelContext)
        {
            _dbContext = dbContext;
            _modelContext = modelContext;
            SetupMappings();
        }
        private void SetupMappings()
        {
            PascalCaseMapper<PlanDTO>.SetTypeMap();
        }
        public async Task<int> CreatePlan(CreatePlanDTO createPlanViewModel)
        {
            DynamicParameters param = new();
            param.Add(name: PlanPackageConstant.PLAN_NAME, createPlanViewModel.PlanName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: PlanPackageConstant.PLAN_DESCRIPTION, createPlanViewModel.PlanDescription, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: PlanPackageConstant.PLAN_PRICE, createPlanViewModel.PlanPrice, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add(name: PlanPackageConstant.C_id, dbType: DbType.Int32, direction: ParameterDirection.Output);


            var res = await _dbContext.Connection.ExecuteAsync(PlanPackageConstant.PLAN_PACKAGE_CREATE_PLAN, param, commandType: CommandType.StoredProcedure);
            int cid = param.Get<int>(name: PlanPackageConstant.C_id);
            return cid;
        }

        public async Task<int> DeletePlan(int id)
        {
            DynamicParameters param = new();
            param.Add(name: PlanPackageConstant.PLAN_ID, id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add(name: PlanPackageConstant.C_id, dbType: DbType.Int32, direction: ParameterDirection.Output);


            var res = await _dbContext.Connection.ExecuteAsync(PlanPackageConstant.PLAN_PACKAGE_DELETE_PLAN, param, commandType: CommandType.StoredProcedure);
            int cid = param.Get<int>(name: PlanPackageConstant.C_id);
            return cid;
        }

        public async Task<int> UpdatePlan(UpdatePlanDTO updatePlanViewModel)
        {
            var existingPlan = await _modelContext.Plans.FindAsync(updatePlanViewModel.PlanId);
            if (existingPlan == null)
            {
                throw new KeyNotFoundException("Plan not found.");
            }


            var planName = updatePlanViewModel.PlanName ?? existingPlan.PlanName;
            var planDescription = updatePlanViewModel.PlanDescription ?? existingPlan.PlanDescription;
            var planPrice = updatePlanViewModel.PlanPrice ?? existingPlan.PlanPrice;

            DynamicParameters param = new();
            param.Add(name: PlanPackageConstant.PLAN_ID, updatePlanViewModel.PlanId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add(name: PlanPackageConstant.PLAN_NAME, planName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: PlanPackageConstant.PLAN_DESCRIPTION, planDescription, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: PlanPackageConstant.PLAN_PRICE, planPrice, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add(name: PlanPackageConstant.C_id, dbType: DbType.Int32, direction: ParameterDirection.Output);

            var res = await _dbContext.Connection.ExecuteAsync(PlanPackageConstant.PLAN_PACKAGE_UPDATE_PLAN, param, commandType: CommandType.StoredProcedure);
            int cid = param.Get<int>(name: PlanPackageConstant.C_id);
            return cid;
        }

        public async Task<PlanDTO> GetPlanById(decimal id)
        {
            DynamicParameters param = new();
            param.Add(name: PlanPackageConstant.PLAN_ID, id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var res = await _dbContext.Connection.QueryFirstOrDefaultAsync<PlanDTO>(PlanPackageConstant.PLAN_PACKAGE_GET_PLAN_BY_ID, param, commandType: CommandType.StoredProcedure);
            return res;
        }

        public async Task<IEnumerable<PlanDTO>> GetAllPlans()
        {
            var res = await _dbContext.Connection.QueryAsync<PlanDTO>(PlanPackageConstant.PLAN_PACKAGE_GET_ALL_PLANS, commandType: CommandType.StoredProcedure);
            return res;
        }
        public async Task<IEnumerable<PlanFeature>> GetPlanFeaturesByPlanId(int planId)
        {
            var res = await _modelContext.PlanFeatures.Where(p => p.PlanId == planId).ToListAsync();
            return res;
        }

        public async Task<PlanDTO?> GetPlanByExamProviderId(decimal examproviderId)
        {
            var examProvider = await _modelContext.ExamProviders.Where(x => x.ExamProviderId == examproviderId).FirstOrDefaultAsync();


            if (examProvider == null)
            {
                return null;
            }

            var plan = await _modelContext.Plans
                .Where(x => x.PlanId == examProvider.PlanId)
                .Select(e => new PlanDTO()
                {
                    PlanName = e.PlanName,
                    PlanDescription = e.PlanDescription,
                    PlanPrice = e.PlanPrice,
                    CreatedAt = e.CreatedAt,
                    PlanId = e.PlanId,

                })
                .FirstOrDefaultAsync();


            return plan;
        }

        public async Task<List<Plan>> GetAllPlansWithFeatures()
        {
            return await _modelContext.Plans.Include(p => p.PlanFeatures).OrderBy(p => p.PlanPrice).ToListAsync();
        }

        public async Task<Plan> GetPlanWithFeatures(decimal id)
        {
            return await _modelContext.Plans!.Include(p => p.PlanFeatures)
                              !.FirstOrDefaultAsync(p => p.PlanId == id)!;
        }

    }

}
