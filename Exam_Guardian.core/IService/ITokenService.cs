using Exam_Guardian.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.IService
{
    public interface ITokenService
    {
        public string GenerateStudentTokenToExam(ExamReservationDTO reservationDTO, ExamInfoDTO examInfoDTO, int roleId, int expirationMinutes);

        public string GenerateToken(ExamReservationDTO reservationDTO,ExamInfoDTO examInfoDTO ,int roleId, int expirationMinutes);
        public string GenerateToken(int roleId, string userId, int expirationMinutes);
        public string GenerateToken(int roleId, string company, string userId, int expirationMinutes);
    }
}


