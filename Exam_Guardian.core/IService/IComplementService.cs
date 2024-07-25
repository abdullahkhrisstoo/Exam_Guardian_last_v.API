using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
namespace Exam_Guardian.core.IService
{
    public interface IComplementService
    {
        Task<int> CreateComplement(CreateComplementDTO createComplementViewModel);
        Task<int> DeleteComplement(int id);
        Task<int> UpdateComplement(UpdateComplementDTO updateComplementViewModel);
        Task<ComplementDTO> GetComplementById(int id);
        Task<IEnumerable<ComplementDTO>> GetAllComplements();

        Task<IEnumerable<Complement>> GetComplementsByProctorId(int id);
        Task<ComplementDTO> GetComplementByExamReservationId(int examReservationId);
    }
}
