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
    public class ExamReservationRepository : IExamReservationRepository
    {
        private readonly IDbContext _dbContext;
        private readonly ModelContext _modelContext;

        public ExamReservationRepository(IDbContext dbContext, ModelContext modelContext)
        {
            _dbContext = dbContext;
            _modelContext = modelContext;
            SetupMappings();
        }
        private void SetupMappings()
        {
            PascalCaseMapper<ExamReservationDTO>.SetTypeMap();
        }

        public async Task<int> CreateExamReservation(CreateExamReservationDTO createExamReservationViewModel)
        {
            DynamicParameters param = new();
            param.Add(name: ExamReservationPackageConstant.STUDENT_TOKEN_EMAIL, createExamReservationViewModel.StudentTokenEmail, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: ExamReservationPackageConstant.START_DATE, createExamReservationViewModel.StartDate, dbType: DbType.Date, direction: ParameterDirection.Input);
            param.Add(name: ExamReservationPackageConstant.END_DATE, createExamReservationViewModel.EndDate, dbType: DbType.Date, direction: ParameterDirection.Input);
            param.Add(name: ExamReservationPackageConstant.PROCTOR_TOKEN_EMAIL, createExamReservationViewModel.ProctorTokenEmail, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: ExamReservationPackageConstant.UNIQUE_KEY, createExamReservationViewModel.UniqueKey, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: ExamReservationPackageConstant.USER_ID, createExamReservationViewModel.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add(name: ExamReservationPackageConstant.STUDENT_NAME, createExamReservationViewModel.StudentName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: ExamReservationPackageConstant.PHONE, createExamReservationViewModel.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: ExamReservationPackageConstant.SCORE, createExamReservationViewModel.Score, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add(name: ExamReservationPackageConstant.EMAIL, createExamReservationViewModel.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: ExamReservationPackageConstant.EXAM_ID, createExamReservationViewModel.ExamId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add(name: ExamReservationPackageConstant.C_id, dbType: DbType.Int32, direction: ParameterDirection.Output);
            var res = await _dbContext.Connection.ExecuteAsync(ExamReservationPackageConstant.EXAM_RESERVATION_PACKAGE_CREATE_EXAM_RESERVATION, param, commandType: CommandType.StoredProcedure);
            int cid = param.Get<int>(name: ExamReservationPackageConstant.C_id);
            return cid;

        }

        public async Task<int> DeleteExamReservation(int id)
        {
            DynamicParameters param = new();
            param.Add(name: ExamReservationPackageConstant.EXAM_RESERVATION_ID, id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add(name: ExamReservationPackageConstant.C_id, dbType: DbType.Int32, direction: ParameterDirection.Output);
            var res = await _dbContext.Connection.ExecuteAsync(ExamReservationPackageConstant.EXAM_RESERVATION_PACKAGE_DELETE_EXAM_RESERVATION, param, commandType: CommandType.StoredProcedure);
            int cid = param.Get<int>(name: ExamReservationPackageConstant.C_id);
            return cid;

        }

        public async Task<int> UpdateExamReservation(UpdateExamReservationDTO updateExamReservationViewModel)
        {
            DynamicParameters param = new();

            var existingExamReservation = await _modelContext.ExamReservations.FindAsync(updateExamReservationViewModel.ExamReservationId);
            if (existingExamReservation == null)
            {

                throw new KeyNotFoundException("Exam reservation not found.");
            }


            var studentTokenEmail = updateExamReservationViewModel.StudentTokenEmail ?? existingExamReservation.StudentTokenEmail;
            var startDate = updateExamReservationViewModel.StartDate ?? existingExamReservation.StartDate;
            var endDate = updateExamReservationViewModel.EndDate ?? existingExamReservation.EndDate;
            var proctorTokenEmail = updateExamReservationViewModel.ProctorTokenEmail ?? existingExamReservation.ProctorTokenEmail;
            var uniqueKey = updateExamReservationViewModel.UniqueKey ?? existingExamReservation.UniqueKey;
            var userId = updateExamReservationViewModel.UserId ?? existingExamReservation.UserId;
            var studentName = updateExamReservationViewModel.StudentName ?? existingExamReservation.StudentName;
            var phone = updateExamReservationViewModel.Phone ?? existingExamReservation.Phone;
            var score = updateExamReservationViewModel.Score ?? existingExamReservation.Score;
            var email = updateExamReservationViewModel.Email ?? existingExamReservation.Email;
            var examId = updateExamReservationViewModel.ExamId ?? existingExamReservation.ExamId;

            param.Add(name: ExamReservationPackageConstant.EXAM_RESERVATION_ID, updateExamReservationViewModel.ExamReservationId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add(name: ExamReservationPackageConstant.STUDENT_TOKEN_EMAIL, studentTokenEmail, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: ExamReservationPackageConstant.START_DATE, startDate, dbType: DbType.Date, direction: ParameterDirection.Input);
            param.Add(name: ExamReservationPackageConstant.END_DATE, endDate, dbType: DbType.Date, direction: ParameterDirection.Input);
            param.Add(name: ExamReservationPackageConstant.PROCTOR_TOKEN_EMAIL, proctorTokenEmail, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: ExamReservationPackageConstant.UNIQUE_KEY, uniqueKey, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: ExamReservationPackageConstant.USER_ID, userId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add(name: ExamReservationPackageConstant.STUDENT_NAME, studentName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: ExamReservationPackageConstant.PHONE, phone, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: ExamReservationPackageConstant.SCORE, score, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add(name: ExamReservationPackageConstant.EMAIL, email, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: ExamReservationPackageConstant.EXAM_ID, examId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add(name: ExamReservationPackageConstant.C_id, dbType: DbType.Int32, direction: ParameterDirection.Output);
            var res = await _dbContext.Connection.ExecuteAsync(ExamReservationPackageConstant.EXAM_RESERVATION_PACKAGE_UPDATE_EXAM_RESERVATION, param, commandType: CommandType.StoredProcedure);
            int cid = param.Get<int>(name: ExamReservationPackageConstant.C_id);
            return cid;

        }

        public async Task<ExamReservationDTO> GetExamReservationById(int id)
        {
            DynamicParameters param = new();
            param.Add(name: ExamReservationPackageConstant.EXAM_RESERVATION_ID, id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var res = await _dbContext.Connection.QueryAsync<ExamReservationDTO>(ExamReservationPackageConstant.EXAM_RESERVATION_PACKAGE_GET_EXAM_RESERVATION_BY_ID, param, commandType: CommandType.StoredProcedure);
            return res.FirstOrDefault()!;
        }

        public async Task<IEnumerable<ExamReservationDTO>> GetAllExamReservations()
        {
            var res = await _dbContext.Connection.QueryAsync<ExamReservationDTO>(ExamReservationPackageConstant.EXAM_RESERVATION_PACKAGE_GET_ALL_EXAM_RESERVATIONS, commandType: CommandType.StoredProcedure);
            return res;
        }

        public async Task<IEnumerable<TimeSlotsViewModel>> GetTimeSlots()
        {
            var res = await _dbContext.Connection.QueryAsync<TimeSlotsViewModel>
                (ExamReservationPackageConstant.EXAM_RESERVATION_PACKAGE_GET_TIME_SLOTS, commandType: CommandType.StoredProcedure);
            return res;
        }

        public async Task<IEnumerable<ExamReservation>> GetAllExamReservationsByProctorId(int id)
        {
            var res = await _modelContext.ExamReservations.Where(x => x.UserId == id).ToListAsync();
            return res;
        }


        public async Task<IEnumerable<ExamReservationDTO>> GetAllExamReservationsByExamId(decimal examId)
        {
            var reservations = await _modelContext.ExamReservations
                .Where(x => x.ExamId == examId)
                .Select(e => new ExamReservationDTO
                {
                    ExamReservationId = e.ExamReservationId,
                    StudentTokenEmail = e.StudentTokenEmail,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    ProctorTokenEmail = e.ProctorTokenEmail,
                    UniqueKey = e.UniqueKey,
                    UserId = e.UserId,
                    CreatedAt = e.CreatedAt,
                    UpdatedAt = e.UpdatedAt,
                    StudentName = e.StudentName,
                    Phone = e.Phone,
                    Score = e.Score,
                    Email = e.Email,
                    ExamId = e.ExamId
                })
                .ToListAsync();

            return reservations;
        }

        public Task<IEnumerable<ExamReservation>> GetExamReservationDependsProctor()
        {
            throw new NotImplementedException();
        }
    }

}
