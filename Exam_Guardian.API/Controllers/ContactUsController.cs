using Exam_Guardian.infra.Repository;
using Exam_Guardian.core.Data;
using Microsoft.AspNetCore.Mvc;
using Exam_Guardian.core.Utilities.ResponseHandler;
using Exam_Guardian.core.IRepository;
using Exam_Guardian.core.IService;

namespace Exam_Guardian.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly IContactUsServices _contactUsServices;

        public ContactUsController(IContactUsServices contactUsServices)
        {
            _contactUsServices = contactUsServices;
        }

        [HttpPost]
        public async Task<IActionResult> CreateContactUs([FromBody] ContactU contact)
        {


            if (contact == null)
            {
                return BadRequest("Contact is null.");
            }

            try
            {
                await _contactUsServices.CreateContactUs(contact);
                return this.ApiResponseOk("Contact created successfully", contact);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactUs(decimal id)
        {
            try
            {
                var result = await _contactUsServices.DeleteContactUs(id);
                if (result > 0)
                {
                    return this.ApiResponseOk("Contact delete successfully", id);
                }
                else
                {
                    return NotFound("Contact not found.");
                }
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { ex });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContactUs()
        {
            try
            {
                var contacts = await _contactUsServices.GetAllContactUs();
                return   this.ApiResponseOk("Contacts retrived successfully", contacts);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { ex });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactUsById(decimal id)
        {
            try
            {
                var contact = await _contactUsServices.GetContactUsById(id);
                if (contact != null)
                {
                    return this.ApiResponseOk("Contact retrived successfully", contact);
                }
                else
                {
                    return NotFound("Contact not found.");
                }
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { ex });
            }
        }
    }
}
