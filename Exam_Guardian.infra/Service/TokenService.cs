using Exam_Guardian.core.IService;
using Exam_Guardian.core.Utilities.TokenConstant;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.infra.Service
{
    public class TokenService : ITokenService
    {
        public string GenerateToken(int roleId, int userId, int expirationMinutes)
        {

            var key = TokenConstant.symmetricSecurityKey;
            var signCred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims  = new List<Claim>
               {
                new Claim("RoleId", roleId.ToString()),
                new Claim("UserId", userId.ToString())
              };



            var tokenOptions = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(expirationMinutes),
                signingCredentials: signCred);

            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return token;
        }
    }
}
