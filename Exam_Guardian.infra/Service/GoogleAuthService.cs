using Exam_Guardian.core.ConstantDB;
using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.infra.Service
{
    public class GoogleAuthService : IGoogleAuthService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthService _authService;

        public GoogleAuthService(IHttpContextAccessor httpContextAccessor, IAuthService authService)
        {
            _httpContextAccessor = httpContextAccessor;
            _authService = authService;
        }

        public string GetAuthenticationUri()
        {
            var properties = new AuthenticationProperties
            {
                RedirectUri = _httpContextAccessor.HttpContext.Request.Scheme + "://" + _httpContextAccessor.HttpContext.Request.Host + "/signin-google"
            };

            return $"/api/auth/google-login?returnUrl={properties.RedirectUri}";
        }

        public async Task AuthenticateAsync()
        {
            var authenticateResult = await _httpContextAccessor!.HttpContext!.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);

            if (!authenticateResult.Succeeded)
            {
                throw new ApplicationException("Failed to authenticate with Google.");
            }

            string storeEmail = authenticateResult.Principal.FindFirst(ClaimTypes.Email)?.Value ?? "";
            if (await _authService.CheckEmailExist(storeEmail) > 0)
            {
                Debug.WriteLine("Email Exist");
                LoginViewModel userCredential = new()
                {
                    Email = storeEmail,
                    Phonenum = null,
                    Password = "123456",
                };
                await _authService.GetUserByCredential(userCredential);
            }
            else
            {
                Debug.WriteLine("E mail not Exist");

                var createAccountViewModel = new CreateAccountViewModel
                {
                    Email = authenticateResult.Principal.FindFirst(ClaimTypes.Email)?.Value,
                    FirstName = authenticateResult.Principal.FindFirst(ClaimTypes.GivenName)?.Value,
                    LastName = authenticateResult.Principal.FindFirst(ClaimTypes.Surname)?.Value,
                    Password = "123456",
                    RoleId = ConstantDB.EXAM_PROVIDER_ROLE
                };
                await _authService.CreateUser(createAccountViewModel);
            }


        }
    }

}
