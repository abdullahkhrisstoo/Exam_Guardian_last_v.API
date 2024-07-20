using Exam_Guardian.core.IService;
using Exam_Guardian.core.Utilities.ResponseHandler;
using Exam_Guardian.core.Utilities.UserRole;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheLearningHub.API.Controllers;

namespace Exam_Guardian.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProctorController : ControllerBase
    {
        private readonly IProctorService _proctorService;
        public ProctorController(IProctorService proctorService) {
            _proctorService = proctorService;
        }
        //[HttpGet]
        //public async Task<IActionResult> GetAllProctor()
        //{
        //    var result = await _proctorService.GetAllProctor();
        //    return Ok(result);
        //}
        [HttpGet("all")]
        //[CheckClaimsAttribute(UserRoleConstant.SAdmin)]
        public async Task<IActionResult> GetAllProctor()
        {
            try
            {
                var result = await _proctorService.GetAllProctor();
                if (result == null || result.Any())
                {
                    return this.ApiResponseNotFound("Proctors not found", new { });
                }
                else { 
                return this.ApiResponseOk("All proctors retrieved successfully", result);
            }}
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { });
            }
        }

        //[HttpGet("{proctorId}")]
        //public async Task<IActionResult> GetProctorById(int proctorId)
        //{
        //    var result = await _proctorService.GetProctorById(proctorId);
        //    return Ok(result);
        //}
        [HttpGet("{proctorId}")]
        //[CheckClaimsAttribute(UserRoleConstant.SAdmin, UserRoleConstant.SProctor)]
        public async Task<IActionResult> GetProctorById(int proctorId)
        {
            try
            {
                var result = await _proctorService.GetProctorById(proctorId);
                if (result == null)
                {
                    return this.ApiResponseNotFound("Proctor not found", new { ProctorId = proctorId });
                }
                return this.ApiResponseOk("Proctor found", result);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { ProctorId = proctorId });
            }
        }

        //[HttpGet("{examReservationId}")]
        //public async Task<IActionResult> GetAllProctor(int examReservationId)
        //{
        //    var result = await _proctorService.GetProctorsByExamReservationId( examReservationId);
        //    return Ok(result);
        //}
        [HttpGet("examReservation/{examReservationId}")]
        //[CheckClaimsAttribute(UserRoleConstant.SAdmin, UserRoleConstant.SProctor)]
        public async Task<IActionResult> GetAllProctor(int examReservationId)
        {
            try
            {
                var result = await _proctorService.GetProctorsByExamReservationId(examReservationId);
                if (result == null )
                {
                    return this.ApiResponseNotFound("Proctor not found by Exam Reservation ID", new { ExamReservationId = examReservationId });
                }
                return this.ApiResponseOk("Proctors by exam reservation ID retrieved successfully", result);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { ExamReservationId = examReservationId });
            }
        }
    } 
}

