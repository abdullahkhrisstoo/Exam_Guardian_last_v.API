using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.IService
{
    public interface IProctorService
    {
      
            Task<UserInfo> GetProctorById(int prcotorId);
            Task<IEnumerable<UserInfo>> GetAllProctor();
            Task<ProctorDTO> GetProctorsByExamReservationId(int examReservationId);
            Task UpdateProctor(decimal id, CreateAccountViewModel createAccountViewModel);


    }
}
