
using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IRepo;
using Exam_Guardian.core.IService;
using Exam_Guardian.core.Utilities.UserRole;

namespace Exam_Guardian.infra.Service
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly ITokenService _tokenService;

        public AuthService(IAuthRepository authRepository, ITokenService tokenService)
        {
            _authRepository = authRepository;
            _tokenService = tokenService;
        }

        public async Task<int> CreateUser(CreateAccountViewModel createProctorViewModel)
        { 
             return  await _authRepository.CreateUser(createProctorViewModel);      
        }


        public async Task<int> DeleteUser(int id) => await _authRepository.DeleteUser(id);
        public async Task<int> UpdateUserPassword(UpdatePasswordViewModel updateProctorPasswordViewModel) => await _authRepository.UpdateUserPassword(updateProctorPasswordViewModel);
       
        
        
        
        
        
        public async Task<LoginResponseViewMdoel> GetUserByCredential(LoginViewModel userCredential)
        {
            LoginResponseViewMdoel userData =   await _authRepository.GetUserByCredential(userCredential);
            try
            {
                int roleId = (int)userData.RoleId;
                int userId = (int)userData.UserId;

                if (userData.UserId is not null)
                {
                    var tokenService = new TokenService();

                    var tokenGenerated = _tokenService.GenerateToken(roleId, userId.ToString(), 120);
                    userData.Token = tokenGenerated;
                    return userData;
                }
                else
                {
                    throw new Exception("Invalid credentials");
                }
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while processing the request", e);
            }
        }



       
        public async Task<UserDataViewModel> GetUserById(int id) => await _authRepository.GetUserById(id);


        public  string GenerateStudentToken(string userId) {


           return  _tokenService.GenerateToken(UserRoleConstant.Student, userId, 1000);
        
        }


        public async Task<int> UpdateName(UpdateNameViewModel update)
        
             => await _authRepository.UpdateName(update);
        

        public async Task<int> UpdatePhone(UpdatePhoneViewModel update)
        
            => await _authRepository.UpdatePhone(update);
        

        public async Task<int> UpdateEmail(UpdateEmailViewModel update)
        
            => await _authRepository.UpdateEmail(update);
        

        public async Task<int> CheckEmailExist(string email)
        
             => await _authRepository.CheckEmailExist(email);
        
    }

     

              


              

      
    
}
