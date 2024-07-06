using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IService;
using Exam_Guardian.core.Utilities.ResponseHandler;
using Exam_Guardian.infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace Exam_Guardian.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestimonalController : ControllerBase
    {
        private readonly ITestimonalService _testimonalService;

        public TestimonalController(ITestimonalService testimonalService)
        {
            _testimonalService = testimonalService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial([FromBody] TestimonalModel testimonial)
        {
            try
            {
                await _testimonalService.CreateTestimonal(testimonial);
                return this.ApiResponseOk("Testimonal created successfully", testimonial);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, testimonial);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestimonial(decimal id)
        {
            try
            {
                await _testimonalService.DeleteTestimonal(id);
                return this.ApiResponseOk("Complement deleted successfully", id);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new {  });
            }
        }

        [HttpGet("approved")]
        public async Task<IActionResult> GetAllApprovedTestimonial()
        {
            try
            {
                var test = await _testimonalService.GetAllApprovedTestimonal();
                if (test == null)
                {
                    return this.ApiResponseNotFound("testimonal not found", new {  });
                }
                return this.ApiResponseOk("Testimonal found", test);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { });
            }
        }

        [HttpGet("rejected")]
        public async Task<IActionResult> GetAllRejectedTestimonial()
        {
            try
            {
                var test = await _testimonalService.GetAllRejectedTestimoanl();
                if (test == null)
                {
                    return this.ApiResponseNotFound("testimonal not found", new { });
                }
                return this.ApiResponseOk("Testimonal found", test);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTestimonial()
        {
            try
            {
                var test = await _testimonalService.GetAllTestimonal();
                return this.ApiResponseOk("Complements retrieved successfully", test);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestimonialById(int id)
        {
            try
            {
                var test = await _testimonalService.GetTestimonialById(id);
                if (test == null) { 
                    return this.ApiResponseNotFound("testimonal not found", new { });
                }
                     return this.ApiResponseOk("Testimonal found", test);
            }
               
            
               catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTestimonals([FromQuery] int? stateId = null, [FromQuery] int? testimonialId = null)
        {
            try
            {
                var testimonials = await _testimonalService.GetAllTestimonals(stateId, testimonialId);
                if (testimonials == null || !testimonials.Any())
                {
                    return this.ApiResponseNotFound("No testimonials found", new { });
                }

                return this.ApiResponseOk("Testimonials found", testimonials);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { });
            }
        }







    }
}
