using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IService;
using Exam_Guardian.core.Utilities.ResponseHandler;
using Exam_Guardian.core.Utilities.UserRole;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheLearningHub.API.Controllers;

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


        [HttpPost]
        //[CheckClaimsAttribute(UserRoleConstant.SAdmin)]
        public async Task<IActionResult> CreatePlanFeature([FromBody] CreatePlanFeatureDTO createPlanFeatureViewModel)
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

        [HttpPut]
        //[CheckClaimsAttribute(UserRoleConstant.SAdmin)]
        public async Task<IActionResult> UpdatePlanFeature([FromBody] UpdatePlanFeatureDTO updatePlanFeatureViewModel)
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



        [HttpDelete("{id}")]
        //[CheckClaimsAttribute(UserRoleConstant.SAdmin)]
        public async Task<IActionResult> DeletePlanFeature(int id)
        {
            try
            {
                await _planFeatureService.DeletePlanFeature(id);
                return this.ApiResponseOk("Plan feature deleted successfully", id);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { PlanFeatureId = id });
            }
        }


        [HttpGet("{id}")]
        //[CheckClaimsAttribute(UserRoleConstant.SAdmin, UserRoleConstant.SExamProvider)]
        public async Task<IActionResult> GetPlanFeatureById(int id)
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

        [HttpGet]
        //[CheckClaimsAttribute(UserRoleConstant.SAdmin, UserRoleConstant.SExamProvider)]
        public async Task<IActionResult> GetAllPlanFeatures()
        {
            try
            {
                var result = await _planFeatureService.GetAllPlanFeatures();
                if (result == null || !result.Any())
                {
                    return this.ApiResponseNotFound("Plan feature not found", new { });
                }
                else
                {


                    return this.ApiResponseOk("All plan features retrieved successfully", result);
                }
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { });
            }
        }






        [HttpGet("{planId}")]
        public async Task<IActionResult> GetPlanFeaturesByPlanId(decimal planId)
        {
            try
            {
                var result = await _planFeatureService.GetPlanFeaturesByPlanId(planId);
                if (result == null || !result.Any())
                {
                    return this.ApiResponseNotFound("Plan feature not found", new { });
                }
                else
                {


                    return this.ApiResponseOk("All plan features retrieved successfully", result);
                }
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { });
            }
        }




    }

}
