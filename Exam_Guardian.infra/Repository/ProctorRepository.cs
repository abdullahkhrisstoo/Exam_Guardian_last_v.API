using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IRepository;
using Exam_Guardian.core.Utilities.UserRole;
using Exam_Guardian.infra.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
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
                .Include(u => u.Credential)
                .Include(ER=>ER.ExamReservations)
                .Where(checkRole => checkRole.RoleId == UserRoleConstant.Proctor)
                .ToListAsync();
            return res;
        }

        public async Task<ProctorDTO> GetProctorsByExamReservationId(int examReservationId)
        {
            var res = await _modelContext.UserInfos
                .Include(er => er.ExamReservations)
                .Where(checkRole => checkRole.RoleId == UserRoleConstant.Proctor)
                .Where(checkExamId => checkExamId.ExamReservations.Any(er => er.ExamReservationId == examReservationId))
                .Select(e => new ProctorDTO()
                {
                    LastName = e.LastName,
                    FirstName = e.LastName,
                    Email = e.Credential.Email,
                    Phone = e.Credential.Phonenum

                })
                .SingleOrDefaultAsync();
            return res;
        }
        public async Task<UserInfo> GetProctorById(int prcotorId)
        {
            var res = await _modelContext.UserInfos
                .SingleOrDefaultAsync(checkRole => (checkRole.RoleId == UserRoleConstant.Proctor) && (checkRole.UserId == prcotorId));
            return res!;
        }



        public async Task UpdateProctor(UpdateAccountDTO updateAccountDTO)
        {
            var userInfo = await _modelContext.UserInfos.FirstOrDefaultAsync(e=>e.UserId==updateAccountDTO.UserId);
            var userCredential = await _modelContext.UserCredentials.FirstOrDefaultAsync(e => e.CredentialId == userInfo.CredentialId);

            
                userInfo.FirstName = updateAccountDTO.FirstName;
                userInfo.LastName = updateAccountDTO.LastName;
                userInfo.UpdatedAt = DateTime.Now;

                userCredential.Email = updateAccountDTO.Email;
                userCredential.Phonenum = updateAccountDTO.Phonenum;
                userCredential.UpdatedAt = DateTime.Now;

                _modelContext.UserInfos.Update(userInfo);
            await _modelContext.SaveChangesAsync();
            _modelContext.UserCredentials.Update(userCredential);
            await _modelContext.SaveChangesAsync();

        }
    }
}
