using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.DTO
{
    public class SDPExchangeModel
    {
        [Required(ErrorMessage = "The SdpMid field is required.")]
        public string SdpMid { get; set; }
        public string SDP { get; set; }
    }



}
