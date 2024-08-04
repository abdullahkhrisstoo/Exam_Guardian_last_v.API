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
    public class ProctorWorkTimesService : IProctorWorkTimesService
    {
        private readonly IProctorWorkTimesRepository _proctorWorkTimesRepository;

        public ProctorWorkTimesService(IProctorWorkTimesRepository proctorWorkTimesRepository)
        {
            _proctorWorkTimesRepository = proctorWorkTimesRepository;
        }

        public async Task<ProctorWorkTime> GetProctorsWorkTimeById(decimal proctorWorkTimesId)
        {
            return await _proctorWorkTimesRepository.GetProctorsWorkTimeById(proctorWorkTimesId);
        }

        public async Task UpdateProctorsWorkTimeById(UpdateProctorWorkTimeDTO update, decimal proctorWorkTimesId)
        {
            await _proctorWorkTimesRepository.UpdateProctorsWorkTimeById(update, proctorWorkTimesId);
        }
    }
}
