




using Exam_Guardian.core.DTO;

namespace Exam_Guardian.core.IRepo
{
    public interface IAuthRepository
    {
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
