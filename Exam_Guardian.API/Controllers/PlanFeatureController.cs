using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IService;
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePlanFeatureViewModel createPlanFeatureViewModel)
        {
            await _planFeatureService.CreatePlanFeature(createPlanFeatureViewModel);
            return Ok(new { message = "Plan feature created successfully" });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePlanFeatureViewModel updatePlanFeatureViewModel)
        {
            await _planFeatureService.UpdatePlanFeature(updatePlanFeatureViewModel);
            return Ok(new { message = "Plan feature updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _planFeatureService.DeletePlanFeature(id);
            return Ok(new { message = "Plan feature deleted successfully" });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _planFeatureService.GetPlanFeatureById(id);
            if (result == null)
            {
                return NotFound(new { message = "Plan feature not found" });
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _planFeatureService.GetAllPlanFeatures();
            return Ok(result);
        }
    }

}
