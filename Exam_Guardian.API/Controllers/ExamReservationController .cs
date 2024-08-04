using Exam_Guardian.api.ResponseHandler;
using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IService;
using Exam_Guardian.core.Utilities.CalimHandler;
using Exam_Guardian.core.Utilities.ResponseHandler;
using Exam_Guardian.core.Utilities.UserRole;
using Exam_Guardian.infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Exam_Guardian.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ExamReservationController : ControllerBase
    {
        private readonly IExamReservationService _examReservationService;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IExamService _examService;
        private readonly IExamInfoService _examInfoService;
        private readonly IExamProviderLinkService _examProviderLinkService;
        private readonly IAuthService _authService;
        public ExamReservationController(IExamReservationService examReservationService,
            IHttpClientFactory httpClientFactory,
            IExamService examService,
            IExamProviderLinkService examProviderLinkService,
            IAuthService authService,
            IExamInfoService examInfoService)
        {
            _examReservationService = examReservationService;
            _httpClientFactory = httpClientFactory;
            _examService = examService;
            _examProviderLinkService = examProviderLinkService;
            _authService = authService;
       
            _examInfoService = examInfoService;
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
        //[CheckClaimsAttribute( UserRoleConstant.SExamProvider)]
        public async Task<IActionResult> GetExamDashToStudent(string token, decimal reservationId)
        {
            try
            {
                var examReservation = await _examReservationService.GetExamReservationById((int)reservationId);

                if (examReservation is null || examReservation.ExamId is null) {

                    return Redirect("");
                }
                if (examReservation.StudentTokenEmail is null || examReservation.StudentTokenEmail!= token)
                {
                    return Redirect("");
                }

                var exam=await _examInfoService.GetExamByIdAsync(examReservation.ExamId.Value);
                var newToken = _authService.GenerateStudentTokenToExam(examReservation,exam);

           
                var pagePath = $"http://localhost:4200/examination/student-test?token={newToken}";

                return Redirect(pagePath);
            }
            catch (Exception ex)
            {
                return Redirect("");
            }
        }
        [HttpGet]
        //[CheckClaimsAttribute( UserRoleConstant.SExamProvider)]
        public async Task<IActionResult> GetExamDashToProctor(string token, decimal reservationId)
        {
            try
            {
                var examReservation = await _examReservationService.GetExamReservationById((int)reservationId);

                if (examReservation is null || examReservation.ExamId is null)
                {

                    return Redirect("");
                }
                if (examReservation.UniqueKey is null || examReservation.UniqueKey != token)
                {

                    return Redirect("");
                }

                var exam = await _examInfoService.GetExamByIdAsync(examReservation.ExamId.Value);
                var newToken = _authService.GenerateProctorTokenToExam(examReservation, exam);


                var pagePath = $"http://localhost:4200/examination/proctor?token={newToken}";

                return Redirect(pagePath);
            }
            catch (Exception ex)
            {
                return Redirect("");
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
            var reservations = await _examReservationService.GetAvailableTimesByDate(dateTime, duration, is24HourFormat);



            var response = new ApiResponseModel<IEnumerable<AvailableTimeDTO>>
            {
                Message = "response retrieved successfully",
                Status = 200,
                Data = reservations
            };
            return Ok(response);
        }


        [HttpPost]
        [CheckClaims(UserRoleConstant.StudentAuth)]
        public async Task<IActionResult> CreateProcessExamReservation(ExamReservationPaymentDTO examReservationPaymentDTO)
        {
            try
            {
                var companyClaim = User.Claims.FirstOrDefault(c => c.Type == "Company")?.Value;

                if (companyClaim == null)
                {
                    return BadRequest("Company claim is missing.");
                }

                var examProvider = await _examService.GetAllExamProviderByExamProviderName(companyClaim);

                if (examProvider == null)
                {
                    return NotFound("Exam provider not found.");
                }

                var key = examProvider.ExamProviderUniqueKey;
                var link = (await _examProviderLinkService.GetExamProviderLinkByCompanyAndActionName(companyClaim, "GetExamByName")).FirstOrDefault();

                var decodedExamName = WebUtility.UrlEncode(examReservationPaymentDTO.ExamName);
                var client = _httpClientFactory.CreateClient();
                var url = $"{link.LinkPath}{key}?examName={decodedExamName}";
                var response = await client.GetAsync(url);

                response.EnsureSuccessStatusCode();
                // var responseBody = await response.Content.ReadAsStringAsync();
                decimal price = 0;
                using (JsonDocument doc = JsonDocument.Parse(await response.Content.ReadAsStringAsync()))
                {
                    var root = doc.RootElement;
                    var resp = root.ValueKind;
                    bool success = root.GetProperty("success").GetBoolean();
                    if (success)
                    {
                        var data = root.GetProperty("data");
                        examReservationPaymentDTO.Price = data.GetProperty("price").GetDecimal();
                        examReservationPaymentDTO.ExamDuration = (int)data.GetProperty("examDuration").GetDecimal();
                        return this.ApiResponseOk("exam booked successfully", await _examReservationService.CreateProcessExamReservation(examReservationPaymentDTO));
                        //return Ok(Content(root.GetRawText(), "application/json").Content);
                        // return RedirectHelper.RedirectByRoleName("Profile", "Admin");
                    }
                    else
                    {
                        return BadRequest(Content(root.GetRawText(), "application/json").Content);

                    }
                }
         
            }
            catch (HttpRequestException httpRequestException)
            {

                return StatusCode(500, $"HTTP request error: {httpRequestException.Message}");
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex,"");

              
            }
        }



    

        [HttpGet("{key}")]
        public async Task<IActionResult> GetAllExamReservationsDetailsByStudentEmail(string key, [FromQuery] string companyName, [FromQuery] string studentEmail)
        {

            var examProvider = await _examService.GetAllExamProviderByExamProviderName(companyName);

            if (examProvider == null)
            {
                return NotFound("Exam provider not found.");
            }

            if (examProvider.ExamProviderUniqueKey != key)
            {

                return BadRequest("Key is wrong");
            }
            var result = await _examReservationService.GetAllExamReservationsDetailsBy(studentEmail);


            return this.ApiResponseOk("All exam reservations retrieved successfully", result);

        }



        [HttpGet("{key}")]
        public async Task<IActionResult> GetAllExamReservationsDetails(string key, [FromQuery] string companyName)
        {

            var examProvider = await _examService.GetAllExamProviderByExamProviderName(companyName);

            if (examProvider == null)
            {
                return NotFound("Exam provider not found.");
            }

            if (examProvider.ExamProviderUniqueKey != key)
            {

                return BadRequest("Key is wrong");
            }
            var result = await _examReservationService.GetAllExamReservationsDetails();


            return this.ApiResponseOk("All exam reservations retrieved successfully", result);

        }






    }
}