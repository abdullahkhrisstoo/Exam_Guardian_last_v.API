using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.DTO
{
    public class RegisterExamProviderDTO
    {

        public CreateAccountViewModel CreateAccountViewModel { get; set; }
        public CardInfoDTO CardInfoDTO { get; set; }
        public IFormFile CommercialRecord { get; set; }
        public decimal PlanId { get; set; }

    }
}
