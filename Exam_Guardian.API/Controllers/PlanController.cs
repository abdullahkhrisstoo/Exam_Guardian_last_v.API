using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IService;
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
        public async Task<IActionResult> Create([FromBody] CreatePlanViewModel createPlanViewModel)
        {
            await _planService.CreatePlan(createPlanViewModel);
            return Ok(new { message = "Plan created successfully" });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePlanViewModel updatePlanViewModel)
        {
            await _planService.UpdatePlan(updatePlanViewModel);
            return Ok(new { message = "Plan updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _planService.DeletePlan(id);
            return Ok(new { message = "Plan deleted successfully" });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _planService.GetPlanById(id);
            if (result == null)
            {
                return NotFound(new { message = "Plan not found" });
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _planService.GetAllPlans();
            return Ok(result);
        }
    }

}
