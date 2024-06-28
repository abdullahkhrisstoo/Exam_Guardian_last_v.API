using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IRepository;
using Exam_Guardian.core.Utilities.UserRole;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.infra.Repository
{
    public class ProctorRepository : IProctorRepository
    {
        private readonly ModelContext _modelContext;
        public ProctorRepository(ModelContext modelContext) 
        {
            _modelContext = modelContext;
        }
        public async Task<IEnumerable<UserInfo>> GetAllProctor()
        {
            var res = await _modelContext.UserInfos
                .Include(u=>u.Credential)
                .Where(checkRole => checkRole.RoleId == UserRoleConstant.Proctor)
                .ToListAsync();
            return res  ;
        }

        public async Task<UserInfo> GetProctorsByExamReservationId(int examReservationId)
        {
            var res = await _modelContext.UserInfos
                .Include(er => er.ExamReservations)
                .Where(checkRole => checkRole.RoleId == UserRoleConstant.Proctor)
                .Where(checkExamId => checkExamId.ExamReservations.Any(er => er.ExamReservationId == examReservationId))
                .SingleOrDefaultAsync();
            return res;
        }

        public async Task<UserInfo> GetProctorById(int prcotorId)
        {
            var res = await _modelContext.UserInfos
                .SingleOrDefaultAsync(checkRole => (checkRole.RoleId == UserRoleConstant.Proctor) &&(checkRole.UserId == prcotorId));
            return res!;
        }
    }
}
