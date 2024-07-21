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
                await _testimonalService.CreateTestimonialAsync(testimonial);
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
                await _testimonalService.DeleteTestimonialAsync(id);
                return this.ApiResponseOk("Complement deleted successfully", id);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new {  });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllApprovedTestimonial()
        {
            try
            {
                var test = await _testimonalService.GetAllApprovedTestimonialsAsync();
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

        [HttpGet]
        public async Task<IActionResult> GetAllRejectedTestimonial()
        {
            try
            {
                var test = await _testimonalService.GetAllRejectedTestimonialsAsync();
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
                var test = await _testimonalService.GetAllTestimonialsAsync();
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
                var test = await _testimonalService.GetTestimonialByIdAsync(id);
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
        public async Task<IActionResult> GetAllPendingTestimonals()
        {
            try
            {
                var testimonials = await _testimonalService.GetPendingTestimonialsAsync();
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



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTestimonial(int id,[FromBody] int testimonalstateid)
        {
            try
            {
                await _testimonalService.UpdateTestimonial(id, testimonalstateid);
                
                return this.ApiResponseOk("Testimonials Updated", new{ });
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { });
            }
        }




    }
}
