using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IService;
using Exam_Guardian.core.Utilities.ResponseHandler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam_Guardian.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IdentificationImageController : ControllerBase
    {
        private readonly IIdentificationImageService _service;

        public IdentificationImageController(IIdentificationImageService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateIdentificationImage([FromForm] CreateIdentificationImageDTO createDto)
        {
            var result = await _service.CreateIdentificationImage(createDto);
            if (result > 0) return this.ApiResponseOk("CreateRoomReservationImage", result);
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateIdentificationImage(UpdateIdentificationImageDTO updateDto)
        {
            var result = await _service.UpdateIdentificationImage(updateDto);
            if (result > 0) return Ok();
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIdentificationImage(decimal id)
        {
            var result = await _service.DeleteIdentificationImage(id);
            if (result > 0) return Ok();
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIdentificationImageById(decimal id)
        {
            var result = await _service.GetIdentificationImageById(id);
            if (result != null)
                return this.ApiResponseOk("Identification Images retrived successfully", result);
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllIdentificationImages()
        {
            var result = await _service.GetAllIdentificationImages();

            return this.ApiResponseOk("Identification Images retrived successfully", result);
        }


        [HttpGet]
        public async Task<IActionResult> GetIdentificationImageBy(decimal reservationId)
        {
            var result = await _service.GetIdentificationImageBy(reservationId);

            return this.ApiResponseOk("Identification Images retrived successfully", result);
        }
    }

}
