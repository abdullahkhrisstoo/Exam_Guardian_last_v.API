using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IService;
using Exam_Guardian.core.Utilities.ResponseHandler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam_Guardian.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PlanController : ControllerBase
    {
        private readonly IPlanService _planService;

        public PlanController(IPlanService planService)
        {
            _planService = planService;
        }

        //[HttpPost]
        //public async Task<IActionResult> Create([FromBody] CreatePlanViewModel createPlanViewModel)
        //{
        //    await _planService.CreatePlan(createPlanViewModel);
        //    return Ok(new { message = "Plan created successfully" });
        //}
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePlanViewModel createPlanViewModel)
        {
            try
            {
                await _planService.CreatePlan(createPlanViewModel);
                return this.ApiResponseOk("Plan created successfully", createPlanViewModel);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, createPlanViewModel);
            }
        }

        //[HttpPut]
        //public async Task<IActionResult> Update([FromBody] UpdatePlanViewModel updatePlanViewModel)
        //{
        //    await _planService.UpdatePlan(updatePlanViewModel);
        //    return Ok(new { message = "Plan updated successfully" });
        //}
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePlanViewModel updatePlanViewModel)
        {
            try
            {
                await _planService.UpdatePlan(updatePlanViewModel);
                return this.ApiResponseOk("Plan updated successfully", updatePlanViewModel);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, updatePlanViewModel);
            }
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    await _planService.DeletePlan(id);
        //    return Ok(new { message = "Plan deleted successfully" });
        //}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _planService.DeletePlan(id);
                return this.ApiResponseOk("Plan deleted successfully",id);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { PlanId = id });
            }
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    var result = await _planService.GetPlanById(id);
        //    if (result == null)
        //    {
        //        return NotFound(new { message = "Plan not found" });
        //    }
        //    return Ok(result);
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _planService.GetPlanById(id);
                if (result == null)
                {
                    return this.ApiResponseNotFound("Plan not found", new { PlanId = id });
                }
                return this.ApiResponseOk("Plan found", result);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { PlanId = id });
            }
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var result = await _planService.GetAllPlans();
        //    return Ok(result);
        //}

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _planService.GetAllPlans();
                if (result == null)
                {
                    return this.ApiResponseNotFound("Plans not found", new { });
                }
                return this.ApiResponseOk("All plans retrieved successfully", result);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { });
            }
        }

        //[HttpGet("{planId}")]
        //public async Task<IActionResult> GetPlanFeaturesByPlanId(int planId)
        //{
        //    var result = await _planService.GetPlanFeaturesByPlanId(planId);
        //    return Ok(result);
        //}
        [HttpGet("features/{planId}")]
        public async Task<IActionResult> GetPlanFeaturesByPlanId(int planId)
        {
            try
            {
                var result = await _planService.GetPlanFeaturesByPlanId(planId);
                if (result == null)
                {
                    return this.ApiResponseNotFound("Plan not found", new { });
                }

                return this.ApiResponseOk("Plan features retrieved successfully", result);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { PlanId = planId });
            }
        }
        //[HttpGet("{examproviderid}")]
        //public async Task<IActionResult> GetPlanByExamBroviderId(int examproviderId)
        //{
        //    var result = await _planService.GetPlanFeaturesByPlanId(examproviderId);
        //    return Ok(result);

        //}
        [HttpGet("examprovider/{examProviderId}")]
        public async Task<IActionResult> GetPlanByExamProviderId(int examProviderId)
        {
            try
            {
                var result = await _planService.GetPlanByExamBroviderId(examProviderId);
                if (result == null)
                {
                    return this.ApiResponseNotFound("Plan not found", new { });
                }
                return this.ApiResponseOk("plans by Exam Provider ID  retrieved successfully", result);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { ExamProviderId = examProviderId });
            }
        }
    }

}
