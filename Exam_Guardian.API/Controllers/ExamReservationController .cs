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
    public class ExamReservationController : ControllerBase
    {
        private readonly IExamReservationService _examReservationService;

        public ExamReservationController(IExamReservationService examReservationService)
        {
            _examReservationService = examReservationService;
        }

        //[HttpPost]
        //public async Task<IActionResult> Create([FromBody] CreateExamReservationViewModel createExamReservationViewModel)
        //{
        //    await _examReservationService.CreateExamReservation(createExamReservationViewModel);
        //    return Ok(new { message = "Exam reservation created successfully" });
        //}
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateExamReservationViewModel createExamReservationViewModel)
        {
            try
            {
                await _examReservationService.CreateExamReservation(createExamReservationViewModel);
                return this.ApiResponseOk("Exam reservation created successfully", createExamReservationViewModel);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { });
            }
        }

        //[HttpPut]
        //public async Task<IActionResult> Update([FromBody] UpdateExamReservationViewModel updateExamReservationViewModel)
        //{
        //    await _examReservationService.UpdateExamReservation(updateExamReservationViewModel);
        //    return Ok(new { message = "Exam reservation updated successfully"});
        //}
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateExamReservationViewModel updateExamReservationViewModel)
        {
            try
            {
                await _examReservationService.UpdateExamReservation(updateExamReservationViewModel);
                return this.ApiResponseOk("Exam reservation updated successfully", updateExamReservationViewModel);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { });
            }
        }


        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    await _examReservationService.DeleteExamReservation(id);
        //    return Ok(new { message = "Exam reservation deleted successfully" });
        //}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _examReservationService.DeleteExamReservation(id);
                return this.ApiResponseOk("Exam reservation deleted successfully", id);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { ExamReservationId = id });
            }
        }


        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    var result = await _examReservationService.GetExamReservationById(id);
        //    if (result == null)
        //    {
        //        return NotFound(new { message = "Exam reservation not found" });
        //    }
        //    return Ok(result);
        //}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _examReservationService.GetExamReservationById(id);
                if (result == null )
                {
                    return this.ApiResponseNotFound("Exam reservation not found", new { ExamReservationId = id });
                }
                return this.ApiResponseOk("Exam reservation found", result);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { ExamReservationId = id });
            }
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var result = await _examReservationService.GetAllExamReservations();
        //    return Ok(result);
        //}

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _examReservationService.GetAllExamReservations();
                if (result == null || !result.Any())
                {
                    return this.ApiResponseNotFound("Exam reservation not found", result);
                }
                else { 
                return this.ApiResponseOk("All exam reservations retrieved successfully", result);
            }
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { });
            }
        }
        //[HttpGet]
        //public async Task<IActionResult> GetTimeSlots()
        //{
        //    var result = await _examReservationService.GetTimeSlots();
        //    return Ok(result);
        //}
        [HttpGet("timeslots")]
        public async Task<IActionResult> GetTimeSlots()
        {
            try
            {
                var result = await _examReservationService.GetTimeSlots();
                if (result == null || !result.Any())
                {
                    return this.ApiResponseNotFound("Time Slots not found", result);
                }
                else { 
                return this.ApiResponseOk("Time slots retrieved successfully", result);}
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { });
            }
        }

        //[HttpGet("{proctorid}")]
        //public async Task<IActionResult>GetAllExamReservationsByProctorId(int id)
        //{
        //    var result = await _examReservationService.GetAllExamReservationsByProctorId(id);
        //    return Ok(result);
        //}

        [HttpGet("proctor/{proctorId}")]
        public async Task<IActionResult> GetAllExamReservationsByProctorId(int proctorId)
        {
            try
            {
                var result = await _examReservationService.GetAllExamReservationsByProctorId(proctorId);
                if (result == null || !result.Any())
                {
                    return this.ApiResponseNotFound("Exam Reservation not found", result);
                }
                else { return this.ApiResponseOk("All exam reservations by proctor ID retrieved successfully", result);}
                
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { ProctorId = proctorId });
            }
        }

    }
}