using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IRepository;
using Exam_Guardian.core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.infra.Service
{
    public class ProctorService : IProctorService
    {
        private readonly IProctorRepository _proctorRepo;
       public ProctorService(IProctorRepository proctorRepository) 
        {
            _proctorRepo = proctorRepository;
        }


        public Task<IEnumerable<UserInfo>> GetAllProctor()
        {
            return _proctorRepo.GetAllProctor();

        }

        public Task<UserInfo> GetProctorById(int prcotorId)
        {
            return _proctorRepo.GetProctorById(prcotorId);
        }

        public Task<ProctorDTO> GetProctorsByExamReservationId(int examReservationId)
        {
            return _proctorRepo.GetProctorsByExamReservationId(examReservationId);
        }

        public Task UpdateProctor(decimal id, CreateAccountViewModel createAccountViewModel)
        {
            return _proctorRepo.UpdateProctor(id, createAccountViewModel);
        }
    }
}
