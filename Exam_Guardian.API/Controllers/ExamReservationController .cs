using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IService;
using Exam_Guardian.core.Utilities.ResponseHandler;
using Exam_Guardian.core.Utilities.UserRole;
using Exam_Guardian.infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Exam_Guardian.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ExamReservationController : ControllerBase
    {
        private readonly IExamReservationService _examReservationService;

        public ExamReservationController(IExamReservationService examReservationService)
        {
            _examReservationService = examReservationService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateExamReservation([FromBody] CreateExamReservationDTO createExamReservationViewModel)
        {
            try
            {
                await _examReservationService.CreateExamReservation(createExamReservationViewModel);
                return this.ApiResponseOk("Exam reservation created successfully", createExamReservationViewModel);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { });
            }
        }


        [HttpPut]
        public async Task<IActionResult> UpdateExamReservation([FromBody] UpdateExamReservationDTO updateExamReservationViewModel)
        {
            try
            {
                await _examReservationService.UpdateExamReservation(updateExamReservationViewModel);
                return this.ApiResponseOk("Exam reservation updated successfully", updateExamReservationViewModel);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { });
            }
        }


        [HttpDelete("{id}")]
        //  [CheckClaimsAttribute(UserRoleConstant.SAdmin)]
        public async Task<IActionResult> DeleteExamReservation(int id)
        {
            try
            {
                await _examReservationService.DeleteExamReservation(id);
                return this.ApiResponseOk("Exam reservation deleted successfully", id);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { ExamReservationId = id });
            }
        }


        [HttpGet("{id}")]
        //[CheckClaimsAttribute( UserRoleConstant.SExamProvider)]
        public async Task<IActionResult> GetExamReservationById(int id)
        {
            try
            {
                var result = await _examReservationService.GetExamReservationById(id);
                if (result == null)
                {
                    return this.ApiResponseNotFound("Exam reservation not found", new { ExamReservationId = id });
                }
                return this.ApiResponseOk("Exam reservation found", result);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { ExamReservationId = id });
            }
        }


        [HttpGet]
        //[CheckClaimsAttribute(UserRoleConstant.SAdmin)]
        public async Task<IActionResult> GetAllExamReservations()
        {
            try
            {
                var result = await _examReservationService.GetAllExamReservations();
                if (result == null || !result.Any())
                {
                    return this.ApiResponseNotFound("Exam reservation not found", result);
                }
                else
                {
                    return this.ApiResponseOk("All exam reservations retrieved successfully", result);
                }
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { });
            }
        }

        [HttpGet()]
        //  [CheckClaimsAttribute(UserRoleConstant.SAdmin, UserRoleConstant.SExamProvider)]
        public async Task<IActionResult> GetTimeSlots()
        {
            try

            {
                var result = await _examReservationService.GetTimeSlot();
                if (result == null || !result.Any())
                {
                    return this.ApiResponseNotFound("Time Slots not found", result);
                }
                else
                {
                    return this.ApiResponseOk("Time slots retrieved successfully", result);
                }
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { });
            }
        }


   

        [HttpGet("{examId}")]
        public async Task<ActionResult<ApiResponseModel<IEnumerable<ExamReservationDTO>>>> GetAllExamReservationsByExamId(decimal examId)
        {
            var reservations = await _examReservationService.GetAllExamReservationsByExamId(examId);

            if (reservations == null || !reservations.Any())
            {
                return NotFound(new ApiResponseModel<IEnumerable<ExamReservationDTO>>
                {
                    Message = "No reservations found for the provided exam ID",
                    Status = 404,
                    Data = null
                });
            }

            var response = new ApiResponseModel<IEnumerable<ExamReservationDTO>>
            {
                Message = "Reservations retrieved successfully",
                Status = 200,
                Data = reservations
            };

            return Ok(response);
        }



        [HttpGet("{proctorId}")]
        public async Task<ActionResult<ApiResponseModel<IEnumerable<ExamReservationProctorDTO>>>> GetAllExamReservationsByProctorId(decimal proctorId)
        {
            var reservations = await _examReservationService.GetAllExamReservationsByProctorId(proctorId);

            if (reservations == null || !reservations.Any())
            {
                return NotFound(new ApiResponseModel<IEnumerable<ExamReservationProctorDTO>>
                {
                    Message = "No reservations found for the provided exam ID",
                    Status = 404,
                    Data = null
                });
            }

            var response = new ApiResponseModel<IEnumerable<ExamReservationProctorDTO>>
            {
                Message = "Reservations retrieved successfully",
                Status = 200,
                Data = reservations
            };

            return Ok(response);
        }


        [HttpGet()]
        public async Task<ActionResult> GetAvailableTimesByDate(DateTime dateTime, int duration, bool is24HourFormat)
        {
            var reservations = await _examReservationService.GetAvailableTimesByDate( dateTime,  duration, is24HourFormat);

            return Ok(reservations);
        }


       

    }
}