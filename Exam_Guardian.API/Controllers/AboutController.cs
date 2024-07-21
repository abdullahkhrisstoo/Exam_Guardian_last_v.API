using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IService;
using Exam_Guardian.core.Utilities.ResponseHandler;
using Exam_Guardian.infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

//last commit
namespace Exam_Guardian.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout([FromBody] AboutDTO aboutDto)
        {
            if (aboutDto == null)
                return this.ApiResponseBadRequest("About data is required.", new{ });
            try
            {
                await _aboutService.CreateAbout(aboutDto);
                return this.ApiResponseOk("About created successfully.", aboutDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbout(decimal id)
        {
            try
            {
                await _aboutService.DeleteAbout(id);
                return this.ApiResponseOk("About deleted successfully.", new{id });
            }
            catch (KeyNotFoundException ex)
            {
                return this.ApiResponseNotFound(ex.Message, new { });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAboutById(decimal id)
        {
            try
            {
                var about = await _aboutService.getAboutById(id);
                if (about == null)
                    return this.ApiResponseNotFound($"About with Id {id} not found.", new { });

                return this.ApiResponseOk("about retrived successfully",about);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError( ex,new { });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAbout()
        {
            try
            {
                var aboutList = await _aboutService.GetAllAbout();
                return this.ApiResponseOk("about retrived successfully", aboutList);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>  UpdateAbout(decimal id, [FromBody]AboutDTO aboutDto)
        {
            if (aboutDto == null)
                return this.ApiResponseBadRequest("About data is required.",new { });

            try
            {
                await _aboutService.UpdateAbout(id,aboutDto);
                return this.ApiResponseOk("about updated successfully" , new { });

            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { });
            }
        }
    }
}
