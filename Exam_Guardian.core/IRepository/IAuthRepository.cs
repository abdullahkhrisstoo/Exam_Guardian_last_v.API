




using Exam_Guardian.core.DTO;

namespace Exam_Guardian.core.IRepo
{
    public interface IAuthRepository
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
