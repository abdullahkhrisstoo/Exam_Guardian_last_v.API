using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IService;
using Exam_Guardian.core.Utilities.ResponseHandler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam_Guardian.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ReservationInvoiceController : ControllerBase
    {
        private readonly IReservationInvoiceService _service;

        public ReservationInvoiceController(IReservationInvoiceService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservationInvoice(CreateReservationInvoiceDTO createDto)
        {
            var result = await _service.CreateReservationInvoice(createDto);
            if (result > 0) return Ok();
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReservationInvoice(UpdateReservationInvoiceDTO updateDto)
        {
            var result = await _service.UpdateReservationInvoice(updateDto);
            if (result > 0) return Ok();
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservationInvoice(decimal id)
        {
            var result = await _service.DeleteReservationInvoice(id);
            if (result > 0) return Ok();
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservationInvoiceById(decimal id)
        {
            var result = await _service.GetReservationInvoiceById(id);
            if (result != null)
                return this.ApiResponseOk("Reservation Invoices retrived successfully", result);
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReservationInvoices()
        {
            var result = await _service.GetAllReservationInvoices();
            return this.ApiResponseOk("Reservation Invoices retrived successfully", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReservationInvoicesDetails()
        {
            var result = await _service.GetAllReservationInvoicesDetails();
            return this.ApiResponseOk("Reservation Invoices retrived successfully", result);
        }
    }

}
