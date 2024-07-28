using Dapper;
using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using Exam_Guardian.core.ICommon;
using Exam_Guardian.core.IRepository;
using Exam_Guardian.core.Mapper;
using Exam_Guardian.core.Utilities.PackagesConstants;
using Exam_Guardian.core.Utilities.UserRole;
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
        public async Task<IEnumerable<ExamReservationProctorDTO>> GetAllExamReservationsByProctorId(decimal userId)
        {
            var reservations = await _modelContext.ExamReservations
                .Where(x => x.UserId == userId)
                .Include(e => e.Exam)
                .Select(e => new ExamReservationProctorDTO
                {
                    ExamReservationId = e.ExamReservationId,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    ProctorTokenEmail = e.ProctorTokenEmail,
                    CreatedAt = e.CreatedAt,
                    UpdatedAt = e.UpdatedAt,
                    StudentName = e.StudentName,
                })
                .ToListAsync();

            return reservations;
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

        public async Task<IEnumerable<AvailableTimeDTO>> GetAvailableTimesByDate(DateTime dateTime, int duration, bool is24HourFormat)
        {
            List<Tuple<TimeSpan, TimeSpan>> reservations = await FetchReservations(dateTime);
            int numberOfProctors = await _modelContext.UserInfos.CountAsync(r => r.RoleId == UserRoleConstant.Proctor);
            List<string> availableSlots = GetAvailableSlots("00:00", "23:59", duration, reservations, numberOfProctors);

            var availableTimeDTOs = availableSlots.Select(slot =>
            {
                var times = slot.Split(' ');
                var start = TimeSpan.Parse(times[0]);
                var end = TimeSpan.Parse(times[2]);

                var startTimeString = FormatTime(start, is24HourFormat);
                var endTimeString = FormatTime(end, is24HourFormat);

                return new AvailableTimeDTO
                {
                    StartTime = dateTime.Date + start,
                    EndTime = dateTime.Date + end,
                    StartTimeFormatted = startTimeString,
                    EndTimeFormatted = endTimeString,
                    Format = is24HourFormat ? "24-hour" : "12-hour"
                };
            }).ToList();

            return availableTimeDTOs;
        }

        private async Task<List<Tuple<TimeSpan, TimeSpan>>> FetchReservations(DateTime dateOfDay)
        {
            return await _modelContext.ExamReservations
                .Where(r => r.StartDate.HasValue && r.EndDate.HasValue && r.StartDate.Value.Date == dateOfDay.Date)
                .Select(r => new Tuple<TimeSpan, TimeSpan>(r.StartDate.Value.TimeOfDay, r.EndDate.Value.TimeOfDay))
                .ToListAsync();
        }

        private List<string> GetAvailableSlots(string startTimeStr, string endTimeStr, int durationMinutes, List<Tuple<TimeSpan, TimeSpan>> reservations, int numberOfProctors)
        {
            reservations.Sort((x, y) => x.Item1.CompareTo(y.Item1));

            TimeSpan startTime = TimeSpan.Parse(startTimeStr);
            TimeSpan endTime = TimeSpan.Parse(endTimeStr);

            List<string> timeSlots = new List<string>();
            TimeSpan examDuration = TimeSpan.FromMinutes(durationMinutes);

            TimeSpan currentTime = startTime;
            while (currentTime + examDuration <= endTime)
            {
                TimeSpan endOfSlot = currentTime + examDuration;

                if (HasAvailableProctors(currentTime, endOfSlot, reservations, numberOfProctors))
                {
                    timeSlots.Add($"{currentTime} to {endOfSlot}");
                }

                currentTime = currentTime.Add(TimeSpan.FromMinutes(1));
            }

            return timeSlots;
        }

        private bool HasAvailableProctors(TimeSpan start, TimeSpan end, List<Tuple<TimeSpan, TimeSpan>> reservations, int numberOfProctors)
        {
            int left = 0;
            int right = reservations.Count - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                var reservation = reservations[mid];

                if (reservation.Item2 <= start)
                {
                    left = mid + 1;
                }
                else if (reservation.Item1 >= end)
                {
                    right = mid - 1;
                }
                else
                {
                    int concurrentExams = 0;
                    for (int i = left; i <= right; i++)
                    {
                        if (reservations[i].Item1 < end && reservations[i].Item2 > start)
                        {
                            concurrentExams++;
                            if (concurrentExams >= numberOfProctors)
                            {
                                return false;
                            }
                        }
                    }
                    return true;
                }
            }

            return true;
        }

        private string FormatTime(TimeSpan time, bool is24HourFormat)
        {
            DateTime dateTime = DateTime.Today.Add(time);
            return is24HourFormat ? dateTime.ToString("HH:mm") : dateTime.ToString("hh:mm tt");
        }

    }


}
