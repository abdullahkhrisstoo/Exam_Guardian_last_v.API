using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
namespace Exam_Guardian.core.IService
{
    public interface IComplementService
    {
        Task CreateComplement(CreateComplementViewModel createComplementViewModel) ;
        Task DeleteComplement(int id);
        Task UpdateComplement(UpdateComplementViewModel updateComplementViewModel);
        Task<ComplementViewModel> GetComplementById(int id);
        Task<IEnumerable<ComplementViewModel>> GetAllComplements();
        Task<Complement> GetComplementByExamReservation(int examreservationId);
        Task<IEnumerable<Complement>> GetComplementsByProctorId(int id);
    }
}
