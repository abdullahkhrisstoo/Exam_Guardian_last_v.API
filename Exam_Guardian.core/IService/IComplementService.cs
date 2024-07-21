using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
namespace Exam_Guardian.core.IService
{
    public interface IComplementService
    {
        Task<int> CreateComplement(CreateComplementViewModel createComplementViewModel);
        Task<int> DeleteComplement(int id);
        Task<int> UpdateComplement(UpdateComplementViewModel updateComplementViewModel);
        Task<ComplementViewModel> GetComplementById(int id);
        Task<IEnumerable<ComplementViewModel>> GetAllComplements();
        Task<Complement> GetComplementByExamReservation(int examreservationId);
        Task<IEnumerable<Complement>> GetComplementsByProctorId(int id);
    }
}
