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
    public class ExamReservationService : IExamReservationService
    {
        private readonly IExamReservationRepository _examReservationRepository;

        public ExamReservationService(IExamReservationRepository examReservationRepository)
        {
            _examReservationRepository = examReservationRepository;
        }

        public async Task CreateExamReservation(CreateExamReservationViewModel createExamReservationViewModel)
        {
            await _examReservationRepository.CreateExamReservation(createExamReservationViewModel);
        }

        public async Task DeleteExamReservation(int id)
        {
            await _examReservationRepository.DeleteExamReservation(id);
        }

        public async Task UpdateExamReservation(UpdateExamReservationViewModel updateExamReservationViewModel)
        {
            await _examReservationRepository.UpdateExamReservation(updateExamReservationViewModel);
        }

        public async Task<ExamReservationViewModel> GetExamReservationById(int id)
        {
            return await _examReservationRepository.GetExamReservationById(id);
        }

        public async Task<IEnumerable<ExamReservationViewModel>> GetAllExamReservations()
        {
            return await _examReservationRepository.GetAllExamReservations();
        }
    }

}
