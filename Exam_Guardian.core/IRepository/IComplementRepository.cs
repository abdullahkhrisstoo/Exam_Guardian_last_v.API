using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.IRepository
{
    public interface IComplementRepository
    {
        Task<int> CreateComplement(CreateComplementViewModel createComplementViewModel);
        Task <int> DeleteComplement(int id);
        Task <int> UpdateComplement(UpdateComplementViewModel updateComplementViewModel);
        Task<ComplementViewModel> GetComplementById(int id);
        Task<IEnumerable<ComplementViewModel>> GetAllComplements();
        Task<Complement> GetComplementByExamReservation(int examreservationId);
        Task<IEnumerable<Complement>> GetComplementsByProctorId(int id);
    }

}
