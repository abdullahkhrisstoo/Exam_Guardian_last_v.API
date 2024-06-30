using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Exam_Guardian.core.Utilities.TokenConstant
{
   static public  class TokenConstant
    {
       static public SymmetricSecurityKey symmetricSecurityKey = new(Encoding.UTF8.GetBytes("Belive in your self,Belive in your self,Belive in your self,Belive in your self,Belive in your self,Belive in your self"));
       static public List<Claim> SetClaims(int roleId, int userId)
        {
            var claims = new List<Claim>
        {
            new Claim("RoleId", roleId.ToString()),
            new Claim("UserId", userId.ToString())
        };

            return claims;
        }
    }
}
