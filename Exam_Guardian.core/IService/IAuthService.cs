
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

        Task CreateUser(CreateAccountViewModel createProctorViewModel);
        Task DeleteUser(int id);
        Task UpdateUserPassword(UpdatePasswordViewModel updateProctorPasswordViewModel);

        Task<UserDataViewModel> GetUserById(int id);
        Task<UserDataViewModel> GetUserByCredential(LoginViewModel userCredential);

        Task UpdateName(UpdateNameViewModel update);
        Task UpdatePhone(UpdatePhoneViewModel update);
        Task UpdateEmail(UpdateEmailViewModel update);
        Task<int> CheckEmailExist(string email);



    }
}
