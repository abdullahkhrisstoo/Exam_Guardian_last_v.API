using Azure;
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
using System.Net.Http;
using System.Reflection;
using System.Text.Json;

namespace Exam_Guardian.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExamInfoController : ControllerBase
    {

        private readonly IExamInfoService _examInfoService;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IExamService _examService;
        private readonly IExamProviderLinkService _examProviderLinkService;
        public ExamInfoController(IExamInfoService examInfoService, IHttpClientFactory httpClientFactory, IExamService examService, IExamProviderLinkService examProviderLinkService)
        {
            _examInfoService = examInfoService;
            _httpClientFactory = httpClientFactory;
               _examService= examService;
            _examProviderLinkService = examProviderLinkService;
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponseModel<ExamInfoDTO>>> CreateExam([FromBody] CreateExamInfoDTO createExamDto)
        {
            var exam = await _examInfoService.CreateExamAsync(createExamDto);
            var response = new ApiResponseModel<ExamInfoDTO>
            {
                Message = "Exam created successfully",
                Status = 201,
                Data = exam
            };
            return CreatedAtAction(nameof(GetExamById), new { id = exam.ExamId }, response);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponseModel<ExamInfoDTO>>> GetExamById(decimal id)
        {
            var exam = await _examInfoService.GetExamByIdAsync(id);
            if (exam == null)
            {
                return NotFound(new ApiResponseModel<ExamInfoDTO>
                {
                    Message = "Exam not found",
                    Status = 404,
                    Data = null
                });
            }
            return Ok(new ApiResponseModel<ExamInfoDTO>
            {
                Message = "Exam retrieved successfully",
                Status = 200,
                Data = exam
            });
        }


        [HttpPut]
        public async Task<ActionResult<ApiResponseModel<bool>>> UpdateExam([FromBody] UpdateExamInfoDTO updateExamDto)
        {


            var result = await _examInfoService.UpdateExamAsync(updateExamDto);
            if (!result)
            {
                return NotFound(new ApiResponseModel<bool>
                {
                    Message = "Exam not found",
                    Status = 404,
                    Data = false
                });
            }

            return Ok(new ApiResponseModel<bool>
            {
                Message = "Exam updated successfully",
                Status = 200,
                Data = true
            });
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponseModel<bool>>> DeleteExam(decimal id)
        {
            var result = await _examInfoService.DeleteExamAsync(id);
            if (!result)
            {
                return NotFound(new ApiResponseModel<bool>
                {
                    Message = "Exam not found",
                    Status = 404,
                    Data = false
                });
            }

            return Ok(new ApiResponseModel<bool>
            {
                Message = "Exam deleted successfully",
                Status = 200,
                Data = true
            });
        }

        [HttpGet("{examProviderId}")]
        public async Task<ActionResult<ApiResponseModel<IEnumerable<ExamInfoDTO>>>> GetExamsByProvider(decimal examProviderId)
        {
            var exams = await _examInfoService.GetExamsByExamProviderIdAsync(examProviderId);
            return Ok(new ApiResponseModel<IEnumerable<ExamInfoDTO>>
            {
                Message = "Exams retrieved successfully",
                Status = 200,
                Data = exams
            });
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponseModel<IEnumerable<ExamInfoDTO>>>> GetAllExams()
        {
            var exams = await _examInfoService.GetAllExams();
            return Ok(new ApiResponseModel<IEnumerable<ExamInfoDTO>>
            {
                Message = "Exams retrieved successfully",
                Status = 200,
                Data = exams
            });
        }
        /*
            [HttpPost]
        public async Task<IActionResult>  Login(LoginViewModel loginViewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsJsonAsync($"{ApiConstants.ApiBaseUrl}:{ApiConstants.ApiPort}/api/auth/login", loginViewModel);
            using (JsonDocument doc = JsonDocument.Parse(await response.Content.ReadAsStringAsync()))
            {
                var root = doc.RootElement;
                var resp = root.ValueKind;
                bool success = root.GetProperty("success").GetBoolean();
                if (success)
                {
                    var data = root.GetProperty("data");
                    HttpContext.Session.SetString("userRole", data.GetProperty("roleId").GetInt32().ToString()??"");
                    HttpContext.Session.SetString("userName", data.GetProperty("userName").GetString());
                    HttpContext.Session.SetString("userEmail", data.GetProperty("userEmail").GetString());

                    return Ok(Content(root.GetRawText(), "application/json").Content);
                  // return RedirectHelper.RedirectByRoleName("Profile", "Admin");
                }
                else {
                    return BadRequest(Content(root.GetRawText(), "application/json").Content);
                    
                }
            }

           
        }*/
        [HttpGet("{key}")]
        public async Task<IActionResult> GetExamByName(string key, string examName)
        {
            var decodedExamName = WebUtility.UrlEncode(examName);
            var client = _httpClientFactory.CreateClient();

            var url = $"https://localhost:7185/api/Exam/GetExamByName/{key}?examName={decodedExamName}";
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ApiResponse<ExamDTO>>(responseBody);

            return Content(responseBody, "application/json");
        }
        [HttpGet("{key}")]
        public async Task<IActionResult> GetExamDetailsByName(string key, string examName)
        {
            var decodedExamName = WebUtility.UrlEncode(examName);
            var client = _httpClientFactory.CreateClient();
            var url = $"https://localhost:7185/api/Exam/GetExamDetailsByName/{key}?examName={decodedExamName}";
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ApiResponse<List<Exam>>>(responseBody);

            return Content(responseBody, "application/json");
        }
        [HttpGet("{key}")]
        public async Task<IActionResult> GetExamDetailsWithoutAnswersByName(string key, string examName)
        {
            var decodedExamName = WebUtility.UrlEncode(examName);
            var client = _httpClientFactory.CreateClient();
            var url = $"https://localhost:7185/api/Exam/GetExamDetailsWithoutAnwersByName/{key}?examName={decodedExamName}";
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ApiResponse<List<Exam>>>(responseBody);

            return Content(responseBody, "application/json");
        }
      
        [HttpGet]
        [CheckClaims(UserRoleConstant.StudentAuth)]
        public async Task<IActionResult> GetExamByName(string examName)
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

            var link=(await _examProviderLinkService.GetExamProviderLinkByCompanyAndActionName(companyClaim, "GetExamByName")).FirstOrDefault();
  
            var decodedExamName = WebUtility.UrlEncode(examName);
            var client = _httpClientFactory.CreateClient();
            var url = $"{link.LinkPath}{key}?examName={decodedExamName}";
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
           // var result = JsonSerializer.Deserialize<ApiResponse<ExamDTO>>(responseBody);

            return Content(responseBody, "application/json");
        }

        [HttpGet]
        [CheckClaims(UserRoleConstant.StudentAuth)]
        public async Task<IActionResult> GetExamDetailsWithoutAnswersByName(string examName)
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
                var link = (await _examProviderLinkService.GetExamProviderLinkByCompanyAndActionName(companyClaim, "GetExamDetailsWithoutAnwersByName")).FirstOrDefault();

                var decodedExamName = WebUtility.UrlEncode(examName);
                var client = _httpClientFactory.CreateClient();
                var url = $"{link.LinkPath}{key}?examName={decodedExamName}";
                var response = await client.GetAsync(url);

                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();

                var result = JsonSerializer.Deserialize<ApiResponse<List<Exam>>>(responseBody);

                if (result == null)
                {
                    return StatusCode(500, "Failed to deserialize the response.");
                }

                return Content(responseBody, "application/json");
            }
            catch (HttpRequestException httpRequestException)
            {
                return StatusCode(500, $"HTTP request error: {httpRequestException.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
            }
        }


        [HttpGet]
        [CheckClaims(UserRoleConstant.SAdmin)]
        public async Task<IActionResult> GetExamDetailsByName(string examName)
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
                var link = (await _examProviderLinkService.GetExamProviderLinkByCompanyAndActionName(companyClaim, "GetExamDetailsByName")).FirstOrDefault();

                var decodedExamName = WebUtility.UrlEncode(examName);
                var client = _httpClientFactory.CreateClient();
                var url = $"{link.LinkPath}{key}?examName={decodedExamName}";
                var response = await client.GetAsync(url);

                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();

                var result = JsonSerializer.Deserialize<ApiResponse<List<Exam>>>(responseBody);

                if (result == null)
                {
                    return StatusCode(500, "Failed to deserialize the response.");
                }

                return Content(responseBody, "application/json");
            }
            catch (HttpRequestException httpRequestException)
            {
                return StatusCode(500, $"HTTP request error: {httpRequestException.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
            }
        }


        [HttpGet]
        [CheckClaims(UserRoleConstant.StudentAuth)]
        public async Task<IActionResult> GetClaims()
        {
            return Ok(User.Claims);

        }

        [HttpPost("{key}")]
        public async Task<IActionResult> AddExamByName(string key,[FromQuery] string companyName, [FromBody] CreateExamInfoDTO createExamDto)
        {

            var examProvider = await _examService.GetAllExamProviderByExamProviderName(companyName);


            var exams = (await _examInfoService.GetAllExams());
            if (exams is not null) {


               var isExamExist= exams.Any(e => e.ExamProviderId == examProvider.ExamProviderId && e.ExamTitle == createExamDto.ExamTitle);
                if (isExamExist is false) {
                    if (examProvider == null)
                    {
                        return NotFound("Exam provider not found.");
                    }

                    if (examProvider.ExamProviderUniqueKey != key)
                    {

                        return BadRequest("Key is wrong");
                    }
                    createExamDto.ExamProviderId = examProvider.ExamProviderId;
                    var exam = await _examInfoService.CreateExamAsync(createExamDto);
                 
                    var response = new ApiResponseModel<ExamInfoDTO>
                    {
                        Message = "Exam created successfully",
                        Status = 201,
                        Data = exam
                    };

                    return CreatedAtAction(nameof(GetExamById), new { id = exam.ExamId }, response);
                }
            }


            return BadRequest("exam is found, we can't add it");

        }

    }
}
