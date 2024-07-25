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
    public class ComplementRepository : IComplementRepository
    {
        private readonly IDbContext _dbContext;
        private readonly ModelContext _modelContext;

        public ComplementRepository(IDbContext dbContext, ModelContext modelContext)
        {
            _dbContext = dbContext;

            _modelContext = modelContext;
            SetupMappings();
        }
        private void SetupMappings()
        {
            PascalCaseMapper<ComplementDTO>.SetTypeMap();
        }

        public async Task<int> CreateComplement(CreateComplementDTO createComplementViewModel)
        {
            DynamicParameters param = new();
            param.Add(name: ComplementPackageConstant.PROCTOR_DESC, createComplementViewModel.ProctorDesc, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: ComplementPackageConstant.STUDENT_DESC, createComplementViewModel.StudentDesc, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: ComplementPackageConstant.EXAM_RESERVATION_ID, createComplementViewModel.ExamReservationId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add(name: ComplementPackageConstant.C_id, dbType: DbType.Int32, direction: ParameterDirection.Output);
            var result = await _dbContext.Connection.ExecuteAsync(ComplementPackageConstant.COMPLEMENT_PACKAGE_CREATE_COMPLEMENT, param, commandType: CommandType.StoredProcedure);
            int complementid = param.Get<int>(name: ComplementPackageConstant.C_id);
            return complementid;

        }

        public async Task<int> DeleteComplement(int id)
        {
            DynamicParameters param = new();
            param.Add(name: ComplementPackageConstant.COMPLEMENT_ID, id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add(name: ComplementPackageConstant.C_id, dbType: DbType.Int32, direction: ParameterDirection.Output);

            var res = await _dbContext.Connection.ExecuteAsync(ComplementPackageConstant.COMPLEMENT_PACKAGE_DELETE_COMPLEMENT, param, commandType: CommandType.StoredProcedure);
            int complementid = param.Get<int>(name: ComplementPackageConstant.C_id);
            return complementid;
        }

        public async Task<int> UpdateComplement(UpdateComplementDTO updateComplementViewModel)
        {
            DynamicParameters param = new();
            var existingComplement = await _modelContext.Complements.FindAsync(updateComplementViewModel.ComplementId);

            var proctorDesc = updateComplementViewModel.ProctorDesc ?? existingComplement.ProctorDesc;
            var studentDesc = updateComplementViewModel.StudentDesc ?? existingComplement.StudentDesc;
            var examReservationId = updateComplementViewModel.ExamReservationId ?? existingComplement.ExamReservationId;

            param.Add(name: ComplementPackageConstant.COMPLEMENT_ID, updateComplementViewModel.ComplementId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add(name: ComplementPackageConstant.PROCTOR_DESC, proctorDesc, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: ComplementPackageConstant.STUDENT_DESC, studentDesc, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: ComplementPackageConstant.EXAM_RESERVATION_ID, examReservationId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add(name: ComplementPackageConstant.C_id, dbType: DbType.Int32, direction: ParameterDirection.Output);
            var res = await _dbContext.Connection.ExecuteAsync(ComplementPackageConstant.COMPLEMENT_PACKAGE_UPDATE_COMPLEMENT, param, commandType: CommandType.StoredProcedure);
            int complementid = param.Get<int>(name: ComplementPackageConstant.C_id);
            return complementid;
        }

        public async Task<ComplementDTO> GetComplementById(int id)
        {
            DynamicParameters param = new();
            param.Add(name: ComplementPackageConstant.COMPLEMENT_ID, id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var res = await _dbContext.Connection.QueryAsync<ComplementDTO>(ComplementPackageConstant.COMPLEMENT_PACKAGE_GET_COMPLEMENT_BY_ID, param, commandType: CommandType.StoredProcedure);
            return res.FirstOrDefault()!;
        }

        public async Task<IEnumerable<ComplementDTO>> GetAllComplements()
        {
            var res = await _dbContext.Connection.QueryAsync<ComplementDTO>(ComplementPackageConstant.COMPLEMENT_PACKAGE_GET_ALL_COMPLEMENTS, commandType: CommandType.StoredProcedure);
            return res;
        }

        public async Task<ComplementDTO> GetComplementByExamReservationId(int examReservationId)
        {
            var res = await _modelContext.Complements.Where(x => x.ExamReservationId == examReservationId)
                .Select(e => new ComplementDTO()
                {
                    ComplementId = e.ComplementId,
                    CreatedAt = e.CreatedAt,
                    ExamReservationId = e.ExamReservationId,
                    ProctorDesc = e.ProctorDesc,
                    StudentDesc = e.StudentDesc,


                })
                .FirstOrDefaultAsync();
            return res;

        }
        public async Task<IEnumerable<Complement>> GetComplementsByProctorId(int id)
        {
            var complements = await _modelContext.UserInfos
        .Where(user => user.UserId == id && user.RoleId == 3)
        .SelectMany(user => user.ExamReservations)
        .SelectMany(reservation => reservation.Complements)
        .ToListAsync();

            return complements;
        }
    }

}
