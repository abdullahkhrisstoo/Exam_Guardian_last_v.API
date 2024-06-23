using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam_Guardian.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ComplementController : ControllerBase
    {
        private readonly IComplementService _complementService;

        public ComplementController(IComplementService complementService)
        {
            _complementService = complementService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateComplementViewModel createComplementViewModel)
        {
            await _complementService.CreateComplement(createComplementViewModel);
            return Ok(new { message = "Complement created successfully" });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateComplementViewModel updateComplementViewModel)
        {
            await _complementService.UpdateComplement(updateComplementViewModel);
            return Ok(new { message = "Complement updated successfully" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _complementService.DeleteComplement(id);
            return Ok(new { message = "Complement deleted successfully" });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _complementService.GetComplementById(id);
            if (result == null)
            {
                return NotFound(new { message = "Complement not found" });
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _complementService.GetAllComplements();
            return Ok(result);
        }
    }

}
