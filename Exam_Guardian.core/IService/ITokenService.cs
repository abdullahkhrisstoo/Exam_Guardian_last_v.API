using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.IService
{
    public interface ITokenService
    {
        public string GenerateToken(int roleId, string userId, int expirationMinutes);
        public string GenerateToken(int roleId, string company, string userId, int expirationMinutes);
    }
}


