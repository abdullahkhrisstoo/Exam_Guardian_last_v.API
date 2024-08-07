﻿
using Exam_Guardian.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.IService
{
    public interface IAuthService
    {
        public string GenerateStudentToken(string userId,string company);
        public string GenerateStudentTokenToExam(ExamReservationDTO examReservationDTO,ExamInfoDTO exam);
        public string GenerateProctorTokenToExam(ExamReservationDTO examReservationDTO, ExamInfoDTO exam);
        Task<int> CreateUser(CreateAccountViewModel createProctorViewModel);
        Task<int> DeleteUser(int id);
        Task<int> UpdateUserPassword(UpdatePasswordViewModel updateProctorPasswordViewModel);

        Task<UserDataViewModel> GetUserById(int id);
        Task<LoginResponseViewMdoel> GetUserByCredential(LoginViewModel userCredential);

        Task<int> UpdateName(UpdateNameViewModel update);
        Task<int> UpdatePhone(UpdatePhoneViewModel update);
        Task<int> UpdateEmail(UpdateEmailViewModel update);
        Task<int> CheckEmailExist(string email);



    }
}
