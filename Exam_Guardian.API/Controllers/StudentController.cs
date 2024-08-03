using Exam_Guardian.api.ResponseHandler;
using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IService;
using Exam_Guardian.core.Utilities.CalimHandler;
using Exam_Guardian.core.Utilities.UserRole;
using Exam_Guardian.infra.Service;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Reflection;
using System.Text.Json;

namespace Exam_Guardian.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class StudentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IExamService _examService;
        private readonly IExamProviderLinkService _examProviderLinkService;
        public StudentController(IHttpClientFactory httpClientFactory , IExamService examService, IExamProviderLinkService examProviderLinkService)
        {   _httpClientFactory = httpClientFactory;
            _examService = examService;
            _examProviderLinkService = examProviderLinkService;
        }
        [HttpGet("{key}")]

        public async Task<IActionResult> GetStudentInfoById(string key, decimal id)
        {
            var client = _httpClientFactory.CreateClient();
            var url = $"https://localhost:7185/api/UserInfo/GetStudentInfoById/{key}?id={id}";
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ApiResponse<StudentDTO>>(responseBody);

            return Content(responseBody, "application/json");
        }

        [HttpGet("{key}")]
        public async Task<IActionResult> GetStudentInfoByEmail(string key,string email)
        {
            var client = _httpClientFactory.CreateClient();
            var url = $"https://localhost:7185/api/UserInfo/GetStudentInfoByEmail/{key}?email={email}";
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ApiResponse<StudentDTO>>(responseBody);

            return Content(responseBody, "application/json");
        }



        [HttpGet]
        [CheckClaims(UserRoleConstant.StudentAuth)]
        public async Task<IActionResult> GetStudentInfoById(decimal id)
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
            var link = (await _examProviderLinkService.GetExamProviderLinkByCompanyAndActionName(companyClaim, "GetStudentInfoById")).FirstOrDefault();

            var client = _httpClientFactory.CreateClient();
            var url = $"{link.LinkPath}{key}?id={id}";
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ApiResponse<StudentDTO>>(responseBody);

            return Content(responseBody, "application/json");
        }

        [HttpGet]
        [CheckClaims(UserRoleConstant.StudentAuth)]
        public async Task<IActionResult> GetStudentInfoByEmail(string email)
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
            var link = (await _examProviderLinkService.GetExamProviderLinkByCompanyAndActionName(companyClaim, "GetStudentInfoByEmail")).FirstOrDefault();

            var client = _httpClientFactory.CreateClient();
            var url = $"{link.LinkPath}{key}?email={email}";
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<ApiResponse<StudentDTO>>(responseBody);

            return Content(responseBody, "application/json");
        }





    }
}
