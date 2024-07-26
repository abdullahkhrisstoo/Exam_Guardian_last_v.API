using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;

namespace Exam_Guardian.core.Utilities.CalimHandler
{

    public class CheckClaimsAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string _claimType= "RoleId";
        private readonly List<string> _claimValues;

        public CheckClaimsAttribute(params string[] claimValues)
        {
            _claimValues = claimValues.ToList();
        }
       

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (!_claimValues.Any(value => user.HasClaim(c => c.Type == _claimType && c.Value == value)))
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }


}
