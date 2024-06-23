
using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IService;
using Exam_Guardian.infra.Repo;
using Exam_Guardian.infra.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

namespace Exam_Guardian.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IEmailService _emailService;
        private readonly IPlanService _planService;
        private readonly IGoogleAuthService _googleAuthService;

        public AuthController(IAuthService authService, IEmailService emailService, IPlanService planService, IGoogleAuthService googleAuthService)
        {
            _authService = authService;
            _emailService = emailService;
            _planService = planService;
            _googleAuthService = googleAuthService;
        }

        [HttpPost]
        public async Task CreateUser([FromBody] CreateAccountViewModel createProctorViewModel)=> await _authService.CreateUser(createProctorViewModel);


        [HttpDelete("{id}")]
        public async Task DeleteUser(int id)=> await _authService.DeleteUser(id);


        [HttpPut]
        public async Task UpdateUserPassword([FromBody] UpdatePasswordViewModel updateProctorPasswordViewModel) => await _authService.UpdateUserPassword(updateProctorPasswordViewModel);


        [HttpPut]
        public async Task UpdateEmail([FromBody] UpdateEmailViewModel update)=> await _authService.UpdateEmail(update);


        [HttpPut]
        public async Task UpdatePhone([FromBody] UpdatePhoneViewModel update)=> await _authService.UpdatePhone(update);

        [HttpPut]
        public async Task UpdateName([FromBody] UpdateNameViewModel update)=> await _authService.UpdateName(update);

        //[HttpGet]
        //public async Task<List<CreateProctorViewModel>> GetAllProctor()
        //    =>await _authService.GetAllProctor();


        [HttpGet("{id}")]
        public async Task<UserDataViewModel> GetUserById(int id) =>await _authService.GetUserById(id);


        [HttpGet]
        public async Task<UserDataViewModel> GetUserByCredential(LoginViewModel userCredential) =>await _authService.GetUserByCredential(userCredential);


        [HttpPost]
        public async Task TestEmail(SendEmailViewModel sendEmailViewModel) => await _emailService.SendEmail(sendEmailViewModel);

    


    [HttpGet]
    public IActionResult GoogleLogin()
    {
        var properties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleCallback") };
        return Challenge(properties, GoogleDefaults.AuthenticationScheme);
    }

    [HttpGet]
    public async Task<IActionResult> GoogleCallback()
    {
        await _googleAuthService.AuthenticateAsync();
        return Ok();

    }


    [HttpGet]
        public async Task<IActionResult> GetPlans()
        {
           return Ok((await _planService.GetAllPlans()));

        }
        [HttpPost]
        public async Task<IActionResult> CreatePlan(CreatePlanViewModel planViewModel)
        {
            await _planService.CreatePlan(planViewModel);
            return Ok();

        }

    }
}
