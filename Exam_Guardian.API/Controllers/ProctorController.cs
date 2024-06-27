using Exam_Guardian.core.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam_Guardian.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProctorController : ControllerBase
    {
        private readonly IProctorService _proctorService;
        public ProctorController(IProctorService proctorService) {
            _proctorService = proctorService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProctor()
        {
            var result = await _proctorService.GetAllProctor();
            return Ok(result);
        }

        [HttpGet("{proctorId}")]
        public async Task<IActionResult> GetProctorById(int proctorId)
        {
            var result = await _proctorService.GetProctorById(proctorId);
            return Ok(result);
        }

        [HttpGet("{examReservationId}")]
        public async Task<IActionResult> GetAllProctor(int examReservationId)
        {
            var result = await _proctorService.GetProctorsByExamReservationId( examReservationId);
            return Ok(result);
        }
    }
}
