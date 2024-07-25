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
        Task<int> CreateComplement(CreateComplementDTO createComplementViewModel);
        Task<int> DeleteComplement(int id);
        Task<int> UpdateComplement(UpdateComplementDTO updateComplementViewModel);
        Task<ComplementDTO> GetComplementById(int id);
        Task<IEnumerable<ComplementDTO>> GetAllComplements();
        Task<ComplementDTO> GetComplementByExamReservationId(int examReservationId);
        Task<IEnumerable<Complement>> GetComplementsByProctorId(int id);
    }

}
