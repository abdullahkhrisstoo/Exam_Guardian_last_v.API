using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IRepository;
using Exam_Guardian.core.IService;
using Exam_Guardian.infra.Utilities.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.infra.Service
{
    public class StatisticsService : IStatisticsService
    {
        private readonly ITestimonalRepositary _testimonalRepositary;
        private readonly IExamProviderRepository _examProviderRepository;
        private readonly IExamReservationRepository _examReservationRepository;
        private readonly IProctorRepository _proctorRepository;

        public StatisticsService(ITestimonalRepositary testimonalRepositary, IExamProviderRepository examProviderRepository, IExamReservationRepository examReservationRepository, IProctorRepository proctorRepository)
        {
            _testimonalRepositary = testimonalRepositary;
            _examProviderRepository = examProviderRepository;
            _examReservationRepository = examReservationRepository;
            _proctorRepository = proctorRepository;
        }

        public async Task<StatisticsViewModel> GetAllStatistics()
        {
            var statistics = new StatisticsViewModel
            {
                //TestimonialApprovedCount = (await _testimonalRepositary.GetAllApprovedTestimonialsAsync()).Count(),
                //TestimonialRejectedCount = (await _testimonalRepositary.GetAllRejectedTestimonialsAsync()).Count(),
                //TestimonialPendingCount = (await _testimonalRepositary.GetPendingTestimonialsAsync()).Count(),
                //AllTestimonialCount = (await _testimonalRepositary.GetAllTestimonialsAsync()).Count(),



                ExamProviderApprovedCount = (await _examProviderRepository.GetExamProvidersByStateId(UserStateConst.Approved)).Count(),
                ExamProviderRejectedCount = (await _examProviderRepository.GetExamProvidersByStateId(UserStateConst.Rejected)).Count(),
                ExamProviderPendingCount = (await _examProviderRepository.GetExamProvidersByStateId(UserStateConst.Pending)).Count(),
                AllExamProviderCount = (await _examProviderRepository.GetAllExamProviders()).Count(),


                AllProctorCount = (await _proctorRepository.GetAllProctor()).Count(),
                AllStudentCount = (await _examReservationRepository.GetAllExamReservations()).Count(),
            };

            return statistics;
        }
    }
}
