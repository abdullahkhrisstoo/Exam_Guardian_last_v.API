using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IService;
using Exam_Guardian.core.Utilities.ResponseHandler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam_Guardian.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExamProviderLinkController : ControllerBase
    {
        private readonly IExamProviderLinkService _service;

        public ExamProviderLinkController(IExamProviderLinkService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateExamProviderLink([FromBody] CreateExamProviderLinkDTO createDto)
        {
            if (createDto == null)
            {
                return BadRequest("Invalid data.");
            }

            var result = await _service.CreateExamProviderLink(createDto);
            return Ok(result); // Return the ID or status code based on your requirements
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExamProviderLink(int id)
        {
            var result = await _service.DeleteExamProviderLink(id);

            if (result == 0)
            {
                return NotFound("Link not found.");
            }

            return NoContent(); // No content to return for deletion
        }

        [HttpPut]
        public async Task<IActionResult> UpdateExamProviderLink([FromBody] UpdateExamProviderLinkDTO updateDto)
        {
            if (updateDto == null)
            {
                return BadRequest("Invalid data.");
            }

            var result = await _service.UpdateExamProviderLink(updateDto);

            if (result == 0)
            {
                return NotFound("Link not found.");
            }

            return NoContent(); // No content to return for update
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExamProviderLinkById(int id)
        {
            var link = await _service.GetExamProviderLinkById(id);

            if (link == null)
            {
                return NotFound("Link not found.");
            }

            return Ok(link);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExamProviderLinks()
        {
            var links = await _service.GetAllExamProviderLinks();
            return this.ApiResponseOk("links retrived successfully", links);
        }

        [HttpGet]
        public async Task<IActionResult> GetExamProviderLinkByCompanyAndActionName([FromQuery] string companyName, [FromQuery] string actionName)
        {
            var links = await _service.GetExamProviderLinkByCompanyAndActionName(companyName, actionName);
            return this.ApiResponseOk("links retrived successfully", links);
        }

        [HttpGet]
        public async Task<IActionResult> GetExamProviderLinkByCompany([FromQuery] string companyName)
        {
            var links = await _service.GetExamProviderLinkByCompany(companyName);
            return this.ApiResponseOk("links retrived successfully", links);
        }

    }
}
