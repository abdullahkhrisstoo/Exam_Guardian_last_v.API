using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IService;
using Exam_Guardian.core.Utilities.ResponseHandler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam_Guardian.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PlanInvoiceController : ControllerBase
    {
        private readonly IPlanInvoiceService _service;

        public PlanInvoiceController(IPlanInvoiceService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlanInvoice(CreatePlanInvoiceDTO createDto)
        {
            var result = await _service.CreatePlanInvoice(createDto);
            if (result > 0) return Ok();
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePlanInvoice(UpdatePlanInvoiceDTO updateDto)
        {
            var result = await _service.UpdatePlanInvoice(updateDto);
            if (result > 0) return Ok();
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlanInvoice(decimal id)
        {
            var result = await _service.DeletePlanInvoice(id);
            if (result > 0) return Ok();
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlanInvoiceById(decimal id)
        {
            var result = await _service.GetPlanInvoiceById(id);
            if (result != null) return this.ApiResponseOk("PlanInvoices retrived successfully", result);
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlanInvoices()
        {
            var result = await _service.GetAllPlanInvoices();
            return this.ApiResponseOk("PlanInvoices retrived successfully", result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPlanInvoicesDetails()
        {
            var result = await _service.GetAllPlanInvoicesDetails();
            return this.ApiResponseOk("PlanInvoices retrived successfully", result);
        }
    }

}
