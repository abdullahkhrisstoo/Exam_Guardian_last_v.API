using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.api.ResponseHandler
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public string Message { get; set; }
        public Dictionary<string, List<string>> Errors { get; set; }
        public ApiResponse()
        {
            Success = true;
        }


        public ApiResponse(T data)
        {
            Success = true;
            Data = data;
        }
        public ApiResponse(T data, bool status)
        {
            Success = status;
            Data = data;
        }
        public ApiResponse(T data, string message, bool status=true)
        {
            Success = status;
            Data = data;
            Message = message;
        }
        public ApiResponse(string message, Dictionary<string, List<string>> validationErrors = null)
        {
            Success = false;
            Data = default;
            Message = message;
            Errors = validationErrors;
        }
    }
}
