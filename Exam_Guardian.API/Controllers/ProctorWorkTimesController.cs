using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IService;
using Exam_Guardian.core.Utilities.ResponseHandler;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Exam_Guardian.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProctorWorkTimesController : ControllerBase
    {
        private readonly IProctorWorkTimesService _proctorWorkTimesService;

        public ProctorWorkTimesController(IProctorWorkTimesService proctorWorkTimesService)
        {
            _proctorWorkTimesService = proctorWorkTimesService;
        }

        [HttpGet("{proctorWorkTimesId}")]
        public async Task<IActionResult> GetProctorsWorkTimeById(decimal proctorWorkTimesId)
        {
            try
            {
                var proctorWork = await _proctorWorkTimesService.GetProctorsWorkTimeById(proctorWorkTimesId);
                if (proctorWork == null)
                    return this.ApiResponseNotFound($"GetProctorsWorkTimeById {proctorWorkTimesId} not found.", new { });

                return this.ApiResponseOk("Proctor work time retrieved successfully", proctorWork);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { });
            }
        }

        [HttpPut("{proctorWorkTimesId}")]
        public async Task<IActionResult> UpdateProctorsWorkTimeById(decimal proctorWorkTimesId, [FromBody] UpdateProctorWorkTimeDTO updateProctorWorkTimeDTO)
        {
            try
            {
                await _proctorWorkTimesService.UpdateProctorsWorkTimeById(updateProctorWorkTimeDTO, proctorWorkTimesId);
                return this.ApiResponseOk("Proctor work time updated successfully", new { });
            }
            catch (ArgumentException ex)
            {
                return this.ApiResponseBadRequest(ex.Message, new { });
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { });
            }
        }
    }
}
