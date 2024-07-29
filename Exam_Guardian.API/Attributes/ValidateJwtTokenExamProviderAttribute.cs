using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Exam_Guardian.core.IService;
using Exam_Guardian.infra.Service;
using Exam_Guardian.API.Attributes;

namespace Exam_Guardian.API.Controllers
{
    public class ValidateJwtTokenExamProviderAttribute : Attribute, IAsyncAuthorizationFilter
    {

        private IExamService _examService;
       
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            try
            {
                var  _examService = ServiceLocator.ServiceProvider.GetService<IExamService>();
            var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Replace("Bearer ", "");
            if (string.IsNullOrEmpty(token))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var companyClaim = ExtractCompanyClaimFromToken(token);
          

            var examProvider = (await _examService.GetAllExamProviderByExamProviderName(companyClaim));

            if (examProvider is null) {
                context.Result = new UnauthorizedResult();
                return;
            }
            var key = examProvider.ExamProviderUniqueKey;

            if (key == null)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var tokenHandler = new JwtSecurityTokenHandler();

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = secretKey,
                ClockSkew = TimeSpan.Zero
            };

            
                tokenHandler.ValidateToken(token, validationParameters, out _);
            }
            catch
            {
                context.Result = new UnauthorizedResult();
            }
        }

        private string ExtractCompanyClaimFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);
            return jwtToken?.Claims.FirstOrDefault(c => c.Type == "company")?.Value;
        }
    }
}