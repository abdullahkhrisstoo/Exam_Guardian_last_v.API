using Dapper;
using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using Exam_Guardian.core.ICommon;
using Exam_Guardian.core.IRepository;
using Exam_Guardian.core.Mapper;
using Exam_Guardian.core.Utilities.PackagesConstants;
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

        public PlanFeatureRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
            SetupMappings();
        }
        private void SetupMappings()
        {
            PascalCaseMapper<PlanFeatureViewModel>.SetTypeMap();
        }

        public async Task<int> CreatePlanFeature(CreatePlanFeatureViewModel createPlanFeatureViewModel)
        {
            DynamicParameters param = new();
            param.Add(name: PlanFeaturePackageConstant.FEATURES_NAME, createPlanFeatureViewModel.FeaturesName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: PlanFeaturePackageConstant.PLAN_ID, createPlanFeatureViewModel.PlanId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add(PlanFeaturePackageConstant.C_id, dbType: DbType.Int32, direction: ParameterDirection.Output);
            
            
            var res = await _dbContext.Connection.ExecuteAsync(PlanFeaturePackageConstant.PLAN_FEATURE_PACKAGE_CREATE_PLAN_FEATURE, param, commandType: CommandType.StoredProcedure);
       int cid = param.Get<int>(PlanFeaturePackageConstant.C_id);
            return cid;
        }

        public async Task <int> DeletePlanFeature(int id)
        {
            DynamicParameters param = new();
            param.Add(name: PlanFeaturePackageConstant.PLAN_FEATURE_ID, id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add(PlanFeaturePackageConstant.C_id, dbType: DbType.Int32, direction: ParameterDirection.Output);
            
            
            var res = await _dbContext.Connection.ExecuteAsync(PlanFeaturePackageConstant.PLAN_FEATURE_PACKAGE_DELETE_PLAN_FEATURE, param, commandType: CommandType.StoredProcedure);
       int cid = param.Get<int>(PlanFeaturePackageConstant.C_id);
            return cid; 
        }

        public async Task <int>UpdatePlanFeature(UpdatePlanFeatureViewModel updatePlanFeatureViewModel)
        {
            DynamicParameters param = new();
            param.Add(name: PlanFeaturePackageConstant.PLAN_FEATURE_ID, updatePlanFeatureViewModel.PlanFeatureId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add(name: PlanFeaturePackageConstant.FEATURES_NAME, updatePlanFeatureViewModel.FeaturesName, dbType: DbType.String, direction: ParameterDirection.Input);
           
           param.Add(name: PlanFeaturePackageConstant.PLAN_ID, updatePlanFeatureViewModel.PlanId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add(name: PlanFeaturePackageConstant.C_id, dbType: DbType.Int32, direction: ParameterDirection.Output);
            
            
            var res = await _dbContext.Connection.ExecuteAsync(PlanFeaturePackageConstant.PLAN_FEATURE_PACKAGE_UPDATE_PLAN_FEATURE, param, commandType: CommandType.StoredProcedure);
            int cid = param.Get<int>(PlanFeaturePackageConstant.C_id);
            return cid;}

        public async Task<PlanFeatureViewModel> GetPlanFeatureById(int id)
        {
            DynamicParameters param = new();
            param.Add(name: PlanFeaturePackageConstant.PLAN_FEATURE_ID, id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var res = await _dbContext.Connection.QueryAsync<PlanFeatureViewModel>(PlanFeaturePackageConstant.PLAN_FEATURE_PACKAGE_GET_PLAN_FEATURE_BY_ID, param, commandType: CommandType.StoredProcedure);
            return res.FirstOrDefault()!;
        }

        public async Task<IEnumerable<PlanFeatureViewModel>> GetAllPlanFeatures()
        {
            var res = await _dbContext.Connection.QueryAsync<PlanFeatureViewModel>(PlanFeaturePackageConstant.PLAN_FEATURE_PACKAGE_GET_ALL_PLAN_FEATURES, commandType: CommandType.StoredProcedure);
            return res;
        }
    }

}
