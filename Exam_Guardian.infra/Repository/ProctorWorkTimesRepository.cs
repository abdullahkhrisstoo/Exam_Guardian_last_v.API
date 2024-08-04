using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.infra.Repository
{
    public class ProctorWorkTimesRepository : IProctorWorkTimesRepository
    {
        private readonly ModelContext _modelContext;
        public ProctorWorkTimesRepository(ModelContext modelContext)
        {
            _modelContext = modelContext;
        }

        public async Task<ProctorWorkTime> GetProctorsWorkTimeById(decimal proctorWorkTimesId)
        {
            return await _modelContext.ProctorWorkTimes.FirstOrDefaultAsync();
        }

        public async Task UpdateProctorsWorkTimeById(UpdateProctorWorkTimeDTO update, decimal proctorWorkTimesId)
        {
            var workTime = await _modelContext.ProctorWorkTimes.FirstOrDefaultAsync();
            if (workTime == null)
            {
                throw new ArgumentException("ProctorWorkTime not found");
            }

            workTime.WorkFrom = update.WorkFrom;
            workTime.WorkTo = update.WorkTo;

            _modelContext.ProctorWorkTimes.Update(workTime);
            await _modelContext.SaveChangesAsync();
        }
    }
}
