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
    public class ComplementRepository : IComplementRepository
    {
        private readonly IDbContext _dbContext;

        public ComplementRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
            SetupMappings();
        }
        private void SetupMappings()
        {
            PascalCaseMapper<ComplementViewModel>.SetTypeMap();
        }

        public async Task CreateComplement(CreateComplementViewModel createComplementViewModel)
        {
            DynamicParameters param = new();
            param.Add(name: ComplementPackageConstant.PROCTOR_DESC, createComplementViewModel.ProctorDesc, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: ComplementPackageConstant.STUDENT_DESC, createComplementViewModel.StudentDesc, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: ComplementPackageConstant.EXAM_RESERVATION_ID, createComplementViewModel.ExamReservationId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var res = await _dbContext.Connection.ExecuteAsync(ComplementPackageConstant.COMPLEMENT_PACKAGE_CREATE_COMPLEMENT, param, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteComplement(int id)
        {
            DynamicParameters param = new();
            param.Add(name: ComplementPackageConstant.COMPLEMENT_ID, id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var res = await _dbContext.Connection.ExecuteAsync(ComplementPackageConstant.COMPLEMENT_PACKAGE_DELETE_COMPLEMENT, param, commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateComplement(UpdateComplementViewModel updateComplementViewModel)
        {
            DynamicParameters param = new();
            param.Add(name: ComplementPackageConstant.COMPLEMENT_ID, updateComplementViewModel.ComplementId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add(name: ComplementPackageConstant.PROCTOR_DESC, updateComplementViewModel.ProctorDesc, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: ComplementPackageConstant.STUDENT_DESC, updateComplementViewModel.StudentDesc, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: ComplementPackageConstant.EXAM_RESERVATION_ID, updateComplementViewModel.ExamReservationId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var res = await _dbContext.Connection.ExecuteAsync(ComplementPackageConstant.COMPLEMENT_PACKAGE_UPDATE_COMPLEMENT, param, commandType: CommandType.StoredProcedure);
        }

        public async Task<ComplementViewModel> GetComplementById(int id)
        {
            DynamicParameters param = new();
            param.Add(name: ComplementPackageConstant.COMPLEMENT_ID, id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var res = await _dbContext.Connection.QueryAsync<ComplementViewModel>(ComplementPackageConstant.COMPLEMENT_PACKAGE_GET_COMPLEMENT_BY_ID, param, commandType: CommandType.StoredProcedure);
            return res.FirstOrDefault()!;
        }

        public async Task<IEnumerable<ComplementViewModel>> GetAllComplements()
        {
            var res = await _dbContext.Connection.QueryAsync<ComplementViewModel>(ComplementPackageConstant.COMPLEMENT_PACKAGE_GET_ALL_COMPLEMENTS, commandType: CommandType.StoredProcedure);
            return res;
        }
    }

}
