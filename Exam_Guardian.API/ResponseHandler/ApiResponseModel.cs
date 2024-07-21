using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.Utilities.ResponseHandler
{
    public class ApiResponseModel<T>
    {
        public string Message { get; set; }
        public int Status { get; set; }
        public T Data { get; set; }
    }
}
