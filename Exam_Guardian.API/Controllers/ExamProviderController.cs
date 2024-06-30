using Exam_Guardian.core.Data;
using Exam_Guardian.core.IService;
using Exam_Guardian.core.Utilities.ResponseHandler;
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

        //[HttpGet]
        //public async Task<IActionResult> GetAllExamProviders()
        //{
        //    var result = await _examService.GetAllExamProviders();
        //    return Ok(result);
        //}
        [HttpGet("all")]
        public async Task<IActionResult> GetAllExamProviders()
        {
            try
            {
                var result = await _examService.GetAllExamProviders();
                if (result == null)
                {
                    return this.ApiResponseNotFound("ExamsProviders  not found", result);
                }
                return this.ApiResponseOk("All exam providers retrieved successfully", result);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new {});
            }
        }


        //[HttpGet("stateId")]
        //public async Task<IActionResult> GetExamProvidersByStateId(int stateId)
        //{
        //    var result = await _examService.GetExamProvidersByStateId(stateId);
        //    return Ok(result);
        //}
        [HttpGet("state/{stateId}")]
        public async Task<IActionResult> GetExamProvidersByStateId(int stateId)
        {
            try
            {
                var result = await _examService.GetExamProvidersByStateId(stateId);
                if (result == null)
                {
                    return this.ApiResponseNotFound("ExamsProviders  not found", result);
                }
                return this.ApiResponseOk("Exam providers by state ID retrieved successfully", result);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { StateId = stateId });
            }
        }
        //[HttpGet("planId")]
        //public async Task<IActionResult> GetExamProvidersByPlanId(int planId)
        //{
        //    var result = await _examService.GetExamProvidersByPlanId(planId);
        //    return Ok(result);
        //}

        [HttpGet("plan/{planId}")]
        public async Task<IActionResult> GetExamProvidersByPlanId(int planId)
        {
            try
            {
                var result = await _examService.GetExamProvidersByPlanId(planId);
                if(result == null)
                {
                    return this.ApiResponseNotFound("ExamsProviders  not found", result);
                }
                return this.ApiResponseOk("Exam providers by plan ID retrieved successfully", result);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { PlanId = planId });
            }
        }
        //[HttpGet("id")]
        //public async Task<IActionResult> GetExamProvidersById(int id)
        //{
        //    var result = await _examService.GetExamProvidersById(id);
        //    return Ok(result);
        //}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExamProvidersById(int id)
        {
            try
            {
                var result = await _examService.GetExamProvidersById(id);
                if(result == null)
                {
                    return this.ApiResponseNotFound("ExamsProviders  not found", result);
                }
                return this.ApiResponseOk("Exam provider by ID retrieved successfully", result);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { Id = id });
            }
        }


    }
}
