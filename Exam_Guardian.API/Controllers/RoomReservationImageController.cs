using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IService;
using Exam_Guardian.core.Utilities.ResponseHandler;
using Exam_Guardian.infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam_Guardian.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RoomReservationImageController : ControllerBase
    {
        private readonly IRoomReservationImageService _service;

        public RoomReservationImageController(IRoomReservationImageService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoomReservationImage([FromForm]  CreateRoomReservationImageDTO createDto)
        {
            var result = await _service.CreateRoomReservationImage(createDto);
            if (result > 0) return this.ApiResponseOk("CreateRoomReservationImage", result);

            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRoomReservationImage(UpdateRoomReservationImageDTO updateDto)
        {
            var result = await _service.UpdateRoomReservationImage(updateDto);
            if (result > 0) return Ok();
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomReservationImage(decimal id)
        {
            var result = await _service.DeleteRoomReservationImage(id);
            if (result > 0) return Ok();
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomReservationImageById(decimal id)
        {
            var result = await _service.GetRoomReservationImageById(id);
            if (result != null)
                return this.ApiResponseOk("Room Reservation Images retrived successfully", result);
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoomReservationImages()
        {
            var result = await _service.GetAllRoomReservationImages();

            return this.ApiResponseOk("Room Reservation Images retrived successfully", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetRoomReservationImagesBy(decimal reservationId)
        {
            var result = await _service.GetAllRoomReservationImagesBy(reservationId);

            return this.ApiResponseOk("Identification Images retrived successfully", result);
        }
    }

}
