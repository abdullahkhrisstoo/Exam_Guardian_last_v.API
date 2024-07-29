using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.DTO
{
    public class WithdrawCardDTO
    {
        public decimal AmountWithDraw { get; set; }
        public CardInfoDTO CardInfoDTO { get; set; }
    }
}
