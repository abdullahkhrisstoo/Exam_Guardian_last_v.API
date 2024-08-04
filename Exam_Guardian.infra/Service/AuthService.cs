
using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IRepo;
using Exam_Guardian.core.IService;
using Exam_Guardian.core.Utilities.UserRole;
using Exam_Guardian.infra.Utilities.States;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

                if (userData.UserId is not null  && (userData.StateId==UserStateConst.Approved || userData.StateId==UserStateConst.Activate))
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


        public  string GenerateStudentToken(string userId,string company) {


           return  _tokenService.GenerateToken(UserRoleConstant.Student, company, userId, 10000);
        
        }


        public async Task<int> UpdateName(UpdateNameViewModel update)
        
             => await _authRepository.UpdateName(update);
        

        public async Task<int> UpdatePhone(UpdatePhoneViewModel update)
        
            => await _authRepository.UpdatePhone(update);
        

        public async Task<int> UpdateEmail(UpdateEmailViewModel update)
        
            => await _authRepository.UpdateEmail(update);
        

        public async Task<int> CheckEmailExist(string email)
        
             => await _authRepository.CheckEmailExist(email);

   
        public string GenerateProctorTokenToExam(ExamReservationDTO examReservationDTO, ExamInfoDTO exam)
        {
            return _tokenService.GenerateToken(examReservationDTO, exam, UserRoleConstant.Proctor, 10000);
        }

        public string GenerateStudentTokenToExam(ExamReservationDTO examReservationDTO, ExamInfoDTO exam)
        {
            return _tokenService.GenerateStudentTokenToExam(examReservationDTO, exam, UserRoleConstant.Examer, 10000);
        }
    }

     

              


              

      
    
}
