using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IService;
using Exam_Guardian.core.Utilities.ResponseHandler;
using Exam_Guardian.core.Utilities.UserRole;
using Microsoft.AspNetCore.Authorization;
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

      

        [HttpPost]
        public async Task<IActionResult> CreateComplement([FromBody] CreateComplementDTO createComplementViewModel)
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


   
        [HttpPut]
        public async Task<IActionResult> UpdateComplement([FromBody] UpdateComplementDTO updateComplementViewModel)
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

      
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComplement(int id)
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


        [HttpGet("{id}")]
       // [CheckClaimsAttribute(UserRoleConstant.SProctor)]//each proctor can see his own complement
        public async Task<IActionResult> GetComplementById(int id)
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
      

        [HttpGet]
        //[CheckClaimsAttribute(UserRoleConstant.SAdmin)]
        public async Task<IActionResult> GetAllComplements()
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
      

        [HttpGet("{examReservationId}")]
       // [CheckClaimsAttribute(UserRoleConstant.SAdmin)]
        public async Task<IActionResult> GetComplementByExamReservationId(int examReservationId)
        {
            try
            {
                var res = await _complementService.GetComplementByExamReservationId(examReservationId);
                if (res is null)
                {
                    return this.ApiResponseNotFound("Complement not found", new { });
                }
                return this.ApiResponseOk("Complements by exam reservation retrieved successfully", res);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { ExamReservationId = examReservationId });
            }
        }


    
        [HttpGet("{proctorId}")]
     //   [CheckClaimsAttribute(UserRoleConstant.SAdmin)]
        public async Task<IActionResult> GetComplementsByProctorId(int proctorId)
        {
            try
            {
                var res = await _complementService.GetComplementsByProctorId(proctorId);
                if (res == null || !res.Any())
                {
                    return this.ApiResponseNotFound("Complement not found", new { });
                }
                else
                {
                    return this.ApiResponseOk("Complements by proctor ID retrieved successfully", res);
                }
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { ProctorId = proctorId });
            }
        }
    }

}
