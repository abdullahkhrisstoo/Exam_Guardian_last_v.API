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
    public class ExamReservationRepository : IExamReservationRepository
    {
        private readonly IDbContext _dbContext;

        public ExamReservationRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
            SetupMappings();
        }
        private void SetupMappings()
        {
            PascalCaseMapper<ExamReservationViewModel>.SetTypeMap();
        }

        public async Task CreateExamReservation(CreateExamReservationViewModel createExamReservationViewModel)
        {
            DynamicParameters param = new();
            param.Add(name: ExamReservationPackageConstant.STUDENT_TOKEN_EMAIL, createExamReservationViewModel.StudentTokenEmail, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: ExamReservationPackageConstant.START_DATE, createExamReservationViewModel.StartDate, dbType: DbType.Date, direction: ParameterDirection.Input);
            param.Add(name: ExamReservationPackageConstant.END_DATE, createExamReservationViewModel.EndDate, dbType: DbType.Date, direction: ParameterDirection.Input);
            param.Add(name: ExamReservationPackageConstant.PROCTOR_TOKEN_EMAIL, createExamReservationViewModel.ProctorTokenEmail, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: ExamReservationPackageConstant.UNIQUE_KEY, createExamReservationViewModel.UniqueKey, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: ExamReservationPackageConstant.USER_ID, createExamReservationViewModel.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var res = await _dbContext.Connection.ExecuteAsync(ExamReservationPackageConstant.EXAM_RESERVATION_PACKAGE_CREATE_EXAM_RESERVATION, param, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteExamReservation(int id)
        {
            DynamicParameters param = new();
            param.Add(name: ExamReservationPackageConstant.EXAM_RESERVATION_ID, id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var res = await _dbContext.Connection.ExecuteAsync(ExamReservationPackageConstant.EXAM_RESERVATION_PACKAGE_DELETE_EXAM_RESERVATION, param, commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateExamReservation(UpdateExamReservationViewModel updateExamReservationViewModel)
        {
            DynamicParameters param = new();
            param.Add(name: ExamReservationPackageConstant.EXAM_RESERVATION_ID, updateExamReservationViewModel.ExamReservationId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add(name: ExamReservationPackageConstant.STUDENT_TOKEN_EMAIL, updateExamReservationViewModel.StudentTokenEmail, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: ExamReservationPackageConstant.START_DATE, updateExamReservationViewModel.StartDate, dbType: DbType.Date, direction: ParameterDirection.Input);
            param.Add(name: ExamReservationPackageConstant.END_DATE, updateExamReservationViewModel.EndDate, dbType: DbType.Date, direction: ParameterDirection.Input);
            param.Add(name: ExamReservationPackageConstant.PROCTOR_TOKEN_EMAIL, updateExamReservationViewModel.ProctorTokenEmail, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: ExamReservationPackageConstant.UNIQUE_KEY, updateExamReservationViewModel.UniqueKey, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: ExamReservationPackageConstant.USER_ID, updateExamReservationViewModel.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var res = await _dbContext.Connection.ExecuteAsync(ExamReservationPackageConstant.EXAM_RESERVATION_PACKAGE_UPDATE_EXAM_RESERVATION, param, commandType: CommandType.StoredProcedure);
        }

        public async Task<ExamReservationViewModel> GetExamReservationById(int id)
        {
            DynamicParameters param = new();
            param.Add(name: ExamReservationPackageConstant.EXAM_RESERVATION_ID, id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var res = await _dbContext.Connection.QueryAsync<ExamReservationViewModel>(ExamReservationPackageConstant.EXAM_RESERVATION_PACKAGE_GET_EXAM_RESERVATION_BY_ID, param, commandType: CommandType.StoredProcedure);
            return res.FirstOrDefault()!;
        }

        public async Task<IEnumerable<ExamReservationViewModel>> GetAllExamReservations()
        {
            var res = await _dbContext.Connection.QueryAsync<ExamReservationViewModel>(ExamReservationPackageConstant.EXAM_RESERVATION_PACKAGE_GET_ALL_EXAM_RESERVATIONS, commandType: CommandType.StoredProcedure);
            return res;
        }
    }

}
