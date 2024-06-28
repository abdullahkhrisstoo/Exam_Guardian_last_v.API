using Exam_Guardian.core.Data;
using Exam_Guardian.core.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam_Guardian.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExamProviderController : ControllerBase
    {
        private readonly IExamService _examService;

        public ExamProviderController(IExamService examService)
        {
            _examService = examService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExamProviders()
        {
            var result = await _examService.GetAllExamProviders();
            return Ok(result);
        }

        [HttpGet("stateId")]
        public async Task<IActionResult> GetExamProvidersByStateId(int stateId)
        {
            var result = await _examService.GetExamProvidersByStateId(stateId);
            return Ok(result);
        }
        [HttpGet("planId")]
        public async Task<IActionResult> GetExamProvidersByPlanId(int planId)
        {
            var result = await _examService.GetExamProvidersByPlanId(planId);
            return Ok(result);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetExamProvidersById(int id)
        {
            var result = await _examService.GetExamProvidersById(id);
            return Ok(result);
        }

    
    }
}
