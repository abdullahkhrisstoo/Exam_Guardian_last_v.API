using Exam_Guardian.core.Mapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Exam_Guardian.core.Utilities.ResponseHandler
{
    public static class ControllerBaseExtensions
    {
        public static IActionResult ApiResponseBadRequest<T>(this ControllerBase controller, string message, T data = default)
        {


            var response = new ApiResponseModel<T>
            {
                Message = message,
                Status = 400,
                Data = data
            };
            return controller.BadRequest(response);
        }

        public static IActionResult ApiResponseOk<T>(this ControllerBase controller, string message, T data = default)
        {
            var response = new ApiResponseModel<T>
            {
                Message = message,
                Status = 200,
                Data = data
            };
            return controller.Ok(response);
        }

        public static IActionResult ApiResponseServerError<T>(this ControllerBase controller, Exception ex, T data = default)
        {
            var response = new ApiResponseModel<T>
            {
                Message = $"Internal server error: {ex.Message}",
                Status = 500,
                Data = data
            };
            return controller.StatusCode(500, response);
        }

        public static IActionResult ApiResponseNotFound<T>(this ControllerBase controller, string message = "Resource not found", T data = default)
        {
            var response = new ApiResponseModel<T>
            {
                Message = message,
                Status = 404,
                Data = data
            };
            return controller.NotFound(response);
        }
    }

}


