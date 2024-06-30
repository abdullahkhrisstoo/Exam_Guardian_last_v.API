using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IService;
using Exam_Guardian.core.Utilities.ResponseHandler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheLearningHub.API.Controllers;

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

        //[HttpPost]
        //public async Task<IActionResult> Create([FromBody] CreateComplementViewModel createComplementViewModel)
        //{
        //    await _complementService.CreateComplement(createComplementViewModel);
        //    return Ok(new { message = "Complement created successfully" });
        //}

        [HttpPost]


        [CheckClaimsAttribute("1")]// i handle it, we don't need to set RoleId word, and the admin id is 1,
        public async Task<IActionResult> Create([FromBody] CreateComplementViewModel createComplementViewModel)
        {
            try
            {
                await _complementService.CreateComplement(createComplementViewModel);
                return this.ApiResponseOk("Complement created successfully", createComplementViewModel);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new {});
            }
        }


        //[HttpPut]
        //public async Task<IActionResult> Update([FromBody] UpdateComplementViewModel updateComplementViewModel)
        //{
        //    await _complementService.UpdateComplement(updateComplementViewModel);
        //    return Ok(new { message = "Complement updated successfully" });
        //}
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateComplementViewModel updateComplementViewModel)
        {
            try
            {
                await _complementService.UpdateComplement(updateComplementViewModel);
                return this.ApiResponseOk("Complement updated successfully", updateComplementViewModel);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { });
            }
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    await _complementService.DeleteComplement(id);
        //    return Ok(new { message = "Complement deleted successfully" });
        //}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _complementService.DeleteComplement(id);
                return this.ApiResponseOk("Complement deleted successfully",id);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { ComplementId = id });
            }
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    var result = await _complementService.GetComplementById(id);
        //    if (result == null)
        //    {
        //        return NotFound(new { message = "Complement not found" });
        //    }
        //    return Ok(result);
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _complementService.GetComplementById(id);
                if (result == null)
                {
                    return this.ApiResponseNotFound("Complement not found", new { ComplementId = id });
                }
                return this.ApiResponseOk("Complement found", result);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { ComplementId = id });
            }
        }
        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var result = await _complementService.GetAllComplements();
        //    return Ok(result);
        //}

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _complementService.GetAllComplements();
                if (result == null)
                {
                    return this.ApiResponseNotFound("Complement not found", new { });
                }
                return this.ApiResponseOk("Complements retrieved successfully", result);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new {});
            }
        }
        //[HttpGet("{examreservationId}")]

        //public async Task<IActionResult> GetcomplementByExamreservation(int examreservationId)
        //{
        //    var res = await _complementService.GetComplementByExamReservation(examreservationId);
        //    return Ok(res);

        //}

        [HttpGet("examreservation/{examreservationId}")]
        public async Task<IActionResult> GetcomplementByExamreservation(int examreservationId)
        {
            try
            {
                var res = await _complementService.GetComplementByExamReservation(examreservationId);
                if (res == null)
                {
                    return this.ApiResponseNotFound("Complement not found", new { });
                }
                return this.ApiResponseOk("Complements by exam reservation retrieved successfully", res);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { ExamReservationId = examreservationId });
            }
        }


        //[HttpGet("{GetComplementsByProctorId}")]
        //public async Task<IActionResult> GetComplementsByProctorId(int id)
        //{
        //    var res= await _complementService.GetComplementsByProctorId(id);
        //    return Ok(res);

        //}

        [HttpGet("proctor/{proctorId}")]
        public async Task<IActionResult> GetComplementsByProctorId(int proctorId)
        {
            try
            {
                var res = await _complementService.GetComplementsByProctorId(proctorId);
                if (res == null)
                {
                    return this.ApiResponseNotFound("Complement not found", new { });
                }
                return this.ApiResponseOk("Complements by proctor ID retrieved successfully", res);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { ProctorId = proctorId });
            }
        }
    }

}
