﻿
using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IRepo;
using Exam_Guardian.core.IService;


namespace Exam_Guardian.infra.Service
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task CreateUser(CreateAccountViewModel createProctorViewModel)
        { 
         await _authRepository.CreateUser(createProctorViewModel);
        
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
                    var token = tokenService.GenerateToken(roleId, userId, 10); 

                    userData.Token = token;

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
