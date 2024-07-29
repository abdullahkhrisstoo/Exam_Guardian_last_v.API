using System;
using System.Collections.Generic;

namespace Exam_Guardian.core.Data
{
    public partial class Card
    {
        public decimal CardId { get; set; }
        public decimal? CardValue { get; set; }
        public string? CardNumber { get; set; }
        public string? CardExpireDate { get; set; }
        public string? CardCvv { get; set; }
        public string? CardHolderName { get; set; }
    }
}
