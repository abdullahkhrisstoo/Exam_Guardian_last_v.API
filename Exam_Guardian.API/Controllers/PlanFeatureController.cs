using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IService;
using Exam_Guardian.core.Utilities.ResponseHandler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam_Guardian.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PlanFeatureController : ControllerBase
    {
        private readonly IPlanFeatureService _planFeatureService;

        public PlanFeatureController(IPlanFeatureService planFeatureService)
        {
            _planFeatureService = planFeatureService;
        }

        //[HttpPost]
        //public async Task<IActionResult> Create([FromBody] CreatePlanFeatureViewModel createPlanFeatureViewModel)
        //{
        //    await _planFeatureService.CreatePlanFeature(createPlanFeatureViewModel);
        //    return Ok(new { message = "Plan feature created successfully" });
        //}
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePlanFeatureViewModel createPlanFeatureViewModel)
        {
            try
            {
                await _planFeatureService.CreatePlanFeature(createPlanFeatureViewModel);
                return this.ApiResponseOk("Plan feature created successfully", createPlanFeatureViewModel);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { });
            }
        }

        //[HttpPut]
        //public async Task<IActionResult> Update([FromBody] UpdatePlanFeatureViewModel updatePlanFeatureViewModel)
        //{
        //    await _planFeatureService.UpdatePlanFeature(updatePlanFeatureViewModel);
        //    return Ok(new { message = "Plan feature updated successfully" });
        //}
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePlanFeatureViewModel updatePlanFeatureViewModel)
        {
            try
            {
                await _planFeatureService.UpdatePlanFeature(updatePlanFeatureViewModel);
                return this.ApiResponseOk("Plan feature updated successfully", updatePlanFeatureViewModel);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { });
            }
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    await _planFeatureService.DeletePlanFeature(id);
        //    return Ok(new { message = "Plan feature deleted successfully" });
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _planFeatureService.DeletePlanFeature(id);
                return this.ApiResponseOk("Plan feature deleted successfully",id);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { PlanFeatureId = id });
            }
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    var result = await _planFeatureService.GetPlanFeatureById(id);
        //    if (result == null)
        //    {
        //        return NotFound(new { message = "Plan feature not found" });
        //    }
        //    return Ok(result);
        //}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _planFeatureService.GetPlanFeatureById(id);
                if (result == null)
                {
                    return this.ApiResponseNotFound("Plan feature not found", new { PlanFeatureId = id });
                }
                return this.ApiResponseOk("Plan feature found", result);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { PlanFeatureId = id });
            }
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var result = await _planFeatureService.GetAllPlanFeatures();
        //    return Ok(result);
        //}
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _planFeatureService.GetAllPlanFeatures();
                if(result == null || !result.Any())
                {
                    return this.ApiResponseNotFound("Plan feature not found", new { });
                }
                else
                {

                
                return this.ApiResponseOk("All plan features retrieved successfully", result);
            }}
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { });
            }
        }
    }

}
