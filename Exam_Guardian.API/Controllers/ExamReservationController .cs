using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exam_Guardian.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ExamReservationController : ControllerBase
    {
        private readonly IExamReservationService _examReservationService;

        public ExamReservationController(IExamReservationService examReservationService)
        {
            _examReservationService = examReservationService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateExamReservationViewModel createExamReservationViewModel)
        {
            await _examReservationService.CreateExamReservation(createExamReservationViewModel);
            return Ok(new { message = "Exam reservation created successfully" });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateExamReservationViewModel updateExamReservationViewModel)
        {
            await _examReservationService.UpdateExamReservation(updateExamReservationViewModel);
            return Ok(new { message = "Exam reservation updated successfully"});
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _examReservationService.DeleteExamReservation(id);
            return Ok(new { message = "Exam reservation deleted successfully" });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _examReservationService.GetExamReservationById(id);
            if (result == null)
            {
                return NotFound(new { message = "Exam reservation not found" });
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _examReservationService.GetAllExamReservations();
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetTimeSlots()
        {
            var result = await _examReservationService.GetTimeSlots();
            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> GetExamReservationDependsProctor()
        {
            var result = await _examReservationService.GetExamReservationDependsProctor();
            return Ok(result);
        }
    }

}