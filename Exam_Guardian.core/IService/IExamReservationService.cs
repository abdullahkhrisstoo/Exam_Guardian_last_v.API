using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.IService
{
    public interface IExamReservationService
    {
        Task CreateExamReservation(CreateExamReservationViewModel createExamReservationViewModel);
        Task DeleteExamReservation(int id);
        Task UpdateExamReservation(UpdateExamReservationViewModel updateExamReservationViewModel);
        Task<ExamReservationViewModel> GetExamReservationById(int id);
        Task<IEnumerable<ExamReservationViewModel>> GetAllExamReservations();
        Task<IEnumerable<UnavailableTimeViewModel>> GetTimeSlots();
        Task<IEnumerable<ExamReservation>> GetAllExamReservationsByProctorId(int id);
    }
}
