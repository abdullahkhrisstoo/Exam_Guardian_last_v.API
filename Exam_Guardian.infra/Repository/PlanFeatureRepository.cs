using Dapper;
using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using Exam_Guardian.core.ICommon;
using Exam_Guardian.core.IRepository;
using Exam_Guardian.core.Mapper;
using Exam_Guardian.core.Utilities.PackagesConstants;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.infra.Repository
{
    public class PlanFeatureRepository : IPlanFeatureRepository
    {
        private readonly IDbContext _dbContext;
        private readonly ModelContext _modelContext;

        public PlanFeatureRepository(IDbContext dbContext, ModelContext modelContext)
        {
            _dbContext = dbContext;
            SetupMappings();
            _modelContext = modelContext;
        }
        private void SetupMappings()
        {
            PascalCaseMapper<PlanFeatureDTO>.SetTypeMap();
        }

        public async Task<int> CreatePlanFeature(CreatePlanFeatureDTO createPlanFeatureViewModel)
        {
            DynamicParameters param = new();
            param.Add(name: PlanFeaturePackageConstant.FEATURES_NAME, createPlanFeatureViewModel.FeaturesName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: PlanFeaturePackageConstant.PLAN_ID, createPlanFeatureViewModel.PlanId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add(PlanFeaturePackageConstant.C_id, dbType: DbType.Int32, direction: ParameterDirection.Output);


            var res = await _dbContext.Connection.ExecuteAsync(PlanFeaturePackageConstant.PLAN_FEATURE_PACKAGE_CREATE_PLAN_FEATURE, param, commandType: CommandType.StoredProcedure);
            int cid = param.Get<int>(PlanFeaturePackageConstant.C_id);
            return cid;
        }

        public async Task<int> DeletePlanFeature(int id)
        {
            DynamicParameters param = new();
            param.Add(name: PlanFeaturePackageConstant.PLAN_FEATURE_ID, id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add(PlanFeaturePackageConstant.C_id, dbType: DbType.Int32, direction: ParameterDirection.Output);


            var res = await _dbContext.Connection.ExecuteAsync(PlanFeaturePackageConstant.PLAN_FEATURE_PACKAGE_DELETE_PLAN_FEATURE, param, commandType: CommandType.StoredProcedure);
            int cid = param.Get<int>(PlanFeaturePackageConstant.C_id);
            return cid;
        }

        public async Task<int> UpdatePlanFeature(UpdatePlanFeatureDTO updatePlanFeatureViewModel)
        {
            DynamicParameters param = new();


            var existingPlanFeature = await _modelContext.PlanFeatures.FindAsync(updatePlanFeatureViewModel.PlanFeatureId);
            if (existingPlanFeature == null)
            {

                throw new KeyNotFoundException("Plan feature not found.");
            }


            var featuresName = updatePlanFeatureViewModel.FeaturesName ?? existingPlanFeature.FeaturesName;
            var planId = updatePlanFeatureViewModel.PlanId ?? existingPlanFeature.PlanId;

            param.Add(name: PlanFeaturePackageConstant.PLAN_FEATURE_ID, updatePlanFeatureViewModel.PlanFeatureId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add(name: PlanFeaturePackageConstant.FEATURES_NAME, featuresName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: PlanFeaturePackageConstant.PLAN_ID, planId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add(name: PlanFeaturePackageConstant.C_id, dbType: DbType.Int32, direction: ParameterDirection.Output);

            var res = await _dbContext.Connection.ExecuteAsync(PlanFeaturePackageConstant.PLAN_FEATURE_PACKAGE_UPDATE_PLAN_FEATURE, param, commandType: CommandType.StoredProcedure);
            int cid = param.Get<int>(PlanFeaturePackageConstant.C_id);
            return cid;
        }

        public async Task<PlanFeatureDTO> GetPlanFeatureById(int id)
        {
            DynamicParameters param = new();
            param.Add(name: PlanFeaturePackageConstant.PLAN_FEATURE_ID, id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var res = await _dbContext.Connection.QueryAsync<PlanFeatureDTO>(PlanFeaturePackageConstant.PLAN_FEATURE_PACKAGE_GET_PLAN_FEATURE_BY_ID, param, commandType: CommandType.StoredProcedure);
            return res.FirstOrDefault()!;
        }

        public async Task<IEnumerable<PlanFeatureDTO>> GetAllPlanFeatures()
        {
            var res = await _dbContext.Connection.QueryAsync<PlanFeatureDTO>(PlanFeaturePackageConstant.PLAN_FEATURE_PACKAGE_GET_ALL_PLAN_FEATURES, commandType: CommandType.StoredProcedure);
            return res;
        }

        public async Task<IEnumerable<PlanFeatureDTO>> GetPlanFeaturesByPlanId(decimal planId)
        {
            var res = await _modelContext.PlanFeatures.Where(p => p.PlanId == planId).Select(e => new PlanFeatureDTO
            {

                FeaturesName = e.FeaturesName,
                CreatedAt = e.CreatedAt,
                PlanId = e.PlanId,
                PlanFeatureId = e.PlanFeatureId
            }).ToListAsync();
            return res;
        }

    }

}
