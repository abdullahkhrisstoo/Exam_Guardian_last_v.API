﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.DTO
{
    public class CreateReservationInvoiceDTO
    {
        public decimal? ExamReservationId { get; set; }
        public decimal? Value { get; set; }
        public DateTime? CreatedAt { get; set; }
    }

}
