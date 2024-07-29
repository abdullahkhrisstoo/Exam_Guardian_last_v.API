using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IService;
using Exam_Guardian.core.Utilities.ResponseHandler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam_Guardian.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExamProviderActionController : ControllerBase
    {
        private readonly IExamProviderActionService _service;

        public ExamProviderActionController(IExamProviderActionService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateExamProviderAction([FromBody] CreateExamProviderActionDTO createDto)
        {
            if (createDto == null)
            {
                return BadRequest("Invalid data.");
            }

            var result = await _service.CreateExamProviderAction(createDto);
            return Ok(result); // Return the ID or status code based on your requirements
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExamProviderAction(int id)
        {
            var result = await _service.DeleteExamProviderAction(id);

            if (result == 0)
            {
                return NotFound("Action not found.");
            }

            return NoContent(); // No content to return for deletion
        }

        [HttpPut]
        public async Task<IActionResult> UpdateExamProviderAction([FromBody] UpdateExamProviderActionDTO updateDto)
        {
            if (updateDto == null)
            {
                return BadRequest("Invalid data.");
            }

            var result = await _service.UpdateExamProviderAction(updateDto);

            if (result == 0)
            {
                return NotFound("Action not found.");
            }

            return NoContent(); // No content to return for update
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExamProviderActionById(int id)
        {
            var action = await _service.GetExamProviderActionById(id);

            if (action == null)
            {
                return NotFound("Action not found.");
            }

            return Ok(action);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExamProviderActions()
        {
            var actions = await _service.GetAllExamProviderActions();
           return this.ApiResponseOk("actions retrived successfully", actions);
        }
    }
}
