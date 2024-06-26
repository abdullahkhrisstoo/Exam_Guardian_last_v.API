﻿
using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IService;
using Exam_Guardian.core.Utilities.ResponseHandler;
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
        public async Task<IActionResult> CreateUser([FromBody] CreateAccountViewModel createProctorViewModel)
        {
            try
            {
                await _authService.CreateUser(createProctorViewModel);
                return this.ApiResponseOk("User created successfully", createProctorViewModel);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { });
            }
        }
        //[HttpDelete("{id}")]
        //public async Task DeleteUser(int id)=> await _authService.DeleteUser(id);
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                await _authService.DeleteUser(id);
                return this.ApiResponseOk("User deleted successfully",id);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { UserId = id });
            }
        }


        //[HttpPut]
        //public async Task UpdateUserPassword([FromBody] UpdatePasswordViewModel updateProctorPasswordViewModel) => await _authService.UpdateUserPassword(updateProctorPasswordViewModel);

        [HttpPut]
        public async Task<IActionResult> UpdateUserPassword([FromBody] UpdatePasswordViewModel updateProctorPasswordViewModel)
        {
            try
            {
                await _authService.UpdateUserPassword(updateProctorPasswordViewModel);
                return this.ApiResponseOk("Password updated successfully", updateProctorPasswordViewModel);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new {});
            }
        }
        //[HttpPut]
        //public async Task UpdateEmail([FromBody] UpdateEmailViewModel update)=> await _authService.UpdateEmail(update);

        [HttpPut]
        public async Task<IActionResult> UpdateEmail([FromBody] UpdateEmailViewModel update)
        {
            try
            {
                await _authService.UpdateEmail(update);
                return this.ApiResponseOk("Email updated successfully", update);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new {});
            }
        }

        //[HttpPut]
        //public async Task UpdatePhone([FromBody] UpdatePhoneViewModel update)=> await _authService.UpdatePhone(update);
        [HttpPut]
        public async Task<IActionResult> UpdatePhone([FromBody] UpdatePhoneViewModel update)
        {
            try
            {
                await _authService.UpdatePhone(update);
                return this.ApiResponseOk("Phone number updated successfully",update);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new {});
            }
        }

        //[HttpPut]
        //public async Task UpdateName([FromBody] UpdateNameViewModel update)=> await _authService.UpdateName(update);
        [HttpPut]
        public async Task<IActionResult> UpdateName([FromBody] UpdateNameViewModel update)
        {
            try
            {
                await _authService.UpdateName(update);
                return this.ApiResponseOk("Name updated successfully",update);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new {});
            }
        }

        //[HttpGet]
        //public async Task<List<CreateProctorViewModel>> GetAllProctor()
        //    =>await _authService.GetAllProctor();


        //[HttpGet("{id}")]
        //public async Task<UserDataViewModel> GetUserById(int id) =>await _authService.GetUserById(id);

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await _authService.GetUserById(id);
                if (user == null)
                {
                    return this.ApiResponseNotFound("User not found", new { UserId = id });
                }
                return this.ApiResponseOk("User found", user);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new { UserId = id });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUserByCredential(LoginViewModel userCredential)
        {
            try
            {
                var userData = await _authService.GetUserByCredential(userCredential);

                if (userData == null)
                {
                    return this.ApiResponseNotFound("User not found", userCredential);
                }

                return this.ApiResponseOk("User found", userData);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new {});
            }
        }


        //[HttpPost]
        //public async Task TestEmail(SendEmailViewModel sendEmailViewModel) => await _emailService.SendEmail(sendEmailViewModel);

        [HttpPost]
        public async Task<IActionResult> TestEmail([FromBody] SendEmailViewModel sendEmailViewModel)
        {
            try
            {
                await _emailService.SendEmail(sendEmailViewModel);
                return this.ApiResponseOk("Email sent successfully", sendEmailViewModel);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new {});
            }
        }


        [HttpGet]
    public IActionResult GoogleLogin()
    {
        var properties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleCallback") };
        return Challenge(properties, GoogleDefaults.AuthenticationScheme);
    }



        //    [HttpGet]
        //public async Task<IActionResult> GoogleCallback()
        //{
        //    await _googleAuthService.AuthenticateAsync();
        //    return Ok();

        //}
        [HttpGet]
        public async Task<IActionResult> GoogleCallback()
        {
            try
            {
                await _googleAuthService.AuthenticateAsync();
                

                return this.ApiResponseOk("Google authentication successful","success");
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new {});
            }
        }


        //[HttpGet]
        //public async Task<IActionResult> GetPlans()
        //{
        //   return Ok((await _planService.GetAllPlans()));

        //}

        [HttpGet]
        public async Task<IActionResult> GetPlans()
        {
            try
            {
                var plans = await _planService.GetAllPlans();
                if (plans == null)
                {
                    return this.ApiResponseNotFound("plans not found", plans);
                }

                return this.ApiResponseOk("Plans retrieved successfully", plans);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new {});
            }
        }
        //[HttpPost]
        //public async Task<IActionResult> CreatePlan(CreatePlanViewModel planViewModel)
        //{
        //    await _planService.CreatePlan(planViewModel);
        //    return Ok();

        //}
        [HttpPost]
        public async Task<IActionResult> CreatePlan([FromBody] CreatePlanViewModel planViewModel)
        {
            try
            {
                await _planService.CreatePlan(planViewModel);
                return this.ApiResponseOk("Plan created successfully", planViewModel);
            }
            catch (Exception ex)
            {
                return this.ApiResponseServerError(ex, new {});
            }
        }

    }
}
