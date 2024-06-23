﻿using Dapper;
using Exam_Guardian.core.DTO;
using Exam_Guardian.core.ICommon;
using Exam_Guardian.core.IRepo;
using Exam_Guardian.core.Mapper;
using Exam_Guardian.core.Utilities.PackagesConstants;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.infra.Repo
{
    public class PlanRepository : IPlanRepository
    {
        private readonly IDbContext _dbContext;

        public PlanRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
            SetupMappings();
        }
        private void SetupMappings()
        {
            PascalCaseMapper<PlanViewModel>.SetTypeMap();
        }
        public async Task CreatePlan(CreatePlanViewModel createPlanViewModel)
        {
            DynamicParameters param = new();
            param.Add(name: PlanPackageConstant.PLAN_NAME, createPlanViewModel.PlanName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: PlanPackageConstant.PLAN_DESCRIPTION, createPlanViewModel.PlanDescription, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: PlanPackageConstant.PLAN_PRICE, createPlanViewModel.PlanPrice, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            var res = await _dbContext.Connection.ExecuteAsync(PlanPackageConstant.PLAN_PACKAGE_CREATE_PLAN, param, commandType: CommandType.StoredProcedure);
        }

        public async Task DeletePlan(int id)
        {
            DynamicParameters param = new();
            param.Add(name: PlanPackageConstant.PLAN_ID, id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var res = await _dbContext.Connection.ExecuteAsync(PlanPackageConstant.PLAN_PACKAGE_DELETE_PLAN, param, commandType: CommandType.StoredProcedure);
        }

        public async Task UpdatePlan(UpdatePlanViewModel updatePlanViewModel)
        {
            DynamicParameters param = new();
            param.Add(name: PlanPackageConstant.PLAN_ID, updatePlanViewModel.PlanId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add(name: PlanPackageConstant.PLAN_NAME, updatePlanViewModel.PlanName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: PlanPackageConstant.PLAN_DESCRIPTION, updatePlanViewModel.PlanDescription, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: PlanPackageConstant.PLAN_PRICE, updatePlanViewModel.PlanPrice, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            var res = await _dbContext.Connection.ExecuteAsync(PlanPackageConstant.PLAN_PACKAGE_UPDATE_PLAN, param, commandType: CommandType.StoredProcedure);
        }

        public async Task<PlanViewModel> GetPlanById(int id)
        {
            DynamicParameters param = new();
            param.Add(name: PlanPackageConstant.PLAN_ID, id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var res = await _dbContext.Connection.QueryFirstOrDefaultAsync<PlanViewModel>(PlanPackageConstant.PLAN_PACKAGE_GET_PLAN_BY_ID, param, commandType: CommandType.StoredProcedure);
            return res;
        }

        public async Task<IEnumerable<PlanViewModel>> GetAllPlans()
        {
            var res = await _dbContext.Connection.QueryAsync<PlanViewModel>(PlanPackageConstant.PLAN_PACKAGE_GET_ALL_PLANS, commandType: CommandType.StoredProcedure);
            return res;
        }
    }

}