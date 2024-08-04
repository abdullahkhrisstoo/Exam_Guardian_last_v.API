﻿using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.IService
{
    public interface IProctorWorkTimesService
    {
        Task<ProctorWorkTime> GetProctorsWorkTimeById(decimal proctorWorkTimesId);
        Task UpdateProctorsWorkTimeById(UpdateProctorWorkTimeDTO update, decimal proctorWorkTimesId);
    }
}
