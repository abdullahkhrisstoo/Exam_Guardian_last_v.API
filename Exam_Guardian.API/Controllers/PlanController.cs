using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IService;
using Exam_Guardian.core.Utilities.ResponseHandler;
using Exam_Guardian.core.Utilities.UserRole;
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

        [HttpPost]
        //[CheckClaimsAttribute(UserRoleConstant.SAdmin)]
        public async Task<IActionResult> CreatePlan([FromBody] CreatePlanDTO createPlanViewModel)
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


        [HttpPut]
        //[CheckClaimsAttribute(UserRoleConstant.SAdmin)]
        public async Task<IActionResult> UpdatePlan([FromBody] UpdatePlanDTO updatePlanViewModel)
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


        [HttpDelete("{id}")]
        //[CheckClaimsAttribute(UserRoleConstant.SAdmin)]
        public async Task<IActionResult> DeletePlan(int id)
        {
            try
            {
                await _planService.DeletePlan(id);
                return this.ApiResponseOk("Plan deleted successfully", id);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { PlanId = id });
            }
        }


        [HttpGet("{id}")]
        //[CheckClaimsAttribute(UserRoleConstant.SAdmin, UserRoleConstant.SExamProvider)]
        public async Task<IActionResult> GetPlanById(int id)
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

        [HttpGet]
        //[CheckClaimsAttribute(UserRoleConstant.SAdmin, UserRoleConstant.SExamProvider)]
        public async Task<IActionResult> GetAllPlans()
        {
            try
            {
                var result = await _planService.GetAllPlans();
                if (result == null || !result.Any())
                {
                    return this.ApiResponseNotFound("Plans not found", new { });
                }
                else
                {
                    return this.ApiResponseOk("All plans retrieved successfully", result);
                }
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { });
            }
        }




        [HttpGet("{examProviderId}")]
        //[CheckClaimsAttribute(UserRoleConstant.SAdmin)]
        public async Task<IActionResult> GetPlanByExamProviderId(int examProviderId)
        {
            try
            {
                var result = await _planService.GetPlanByExamProviderId(examProviderId);
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
        [HttpGet]
        public async Task<IActionResult> GetAllPlansWithFeatures()
        {
            try
            {
                var result = await _planService.GetAllPlansWithFeatures();
                if (result == null)
                {
                    return this.ApiResponseNotFound("Plan not found", new { });
                }
                return this.ApiResponseOk("Get All Plans With Features  retrieved successfully", result);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { });
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlanWithFeatures(decimal id)
        {
            try
            {
                var result = await _planService.GetPlanWithFeatures(id);
                if (result == null)
                {
                    return this.ApiResponseNotFound("Plan not found", new { });
                }
                return this.ApiResponseOk("Get Plan With Features  retrieved successfully", result);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { ExamProviderId = id });
            }
        }
    }

}
