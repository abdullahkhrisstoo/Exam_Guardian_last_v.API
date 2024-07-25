using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IRepository;
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
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonalService _testimonalService;

        public TestimonialController(ITestimonalService testimonalService)
        {
            _testimonalService = testimonalService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial([FromBody] CreateTestimonailDTO testimonial)
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
                return this.ApiResponseServerError(ex, new { });
            }
        }



        [HttpGet]
        public async Task<IActionResult> GetAllTestimonials()
        {
            try
            {
                var test = await _testimonalService.GetAllTestimonials();
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


        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestimonialsByExamProviderId(decimal id)
        {
            try
            {
                var test = await _testimonalService.GetTestimonialsByExamProviderId(id);
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestimonialsByStateId(decimal id)
        {
            try
            {
                var test = await _testimonalService.GetTestimonialsByStateId(id);
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


        [HttpPut]
        public async Task<IActionResult> UpdateTestimonialState(decimal testimonialId, decimal stateId)
        {
            return this.ApiResponseOk("Tetimonial is Updated", await _testimonalService.UpdateTestimonialState(testimonialId, stateId));

        }





    }
}
