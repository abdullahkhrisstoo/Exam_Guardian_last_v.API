using Dapper;

using Exam_Guardian.core.DTO;
using Exam_Guardian.core.ICommon;
using Exam_Guardian.core.IRepo;
using Exam_Guardian.core.Utilities.PackagesConstants;
using System.Data;


namespace Exam_Guardian.infra.Repo
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IDbContext _dbContext;

        public AuthRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

          public async Task CreateUser(CreateAccountViewModel createProctorViewModel)
        {
            DynamicParameters param = new();
            param.Add(name: AuthPackageConstant.V_FIRST_NAME, createProctorViewModel.FirstName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: AuthPackageConstant.V_LAST_NAME, createProctorViewModel.LastName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: AuthPackageConstant.V_EMAIL, createProctorViewModel.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: AuthPackageConstant.V_ROLE, createProctorViewModel.RoleId, dbType: DbType.Int16, direction: ParameterDirection.Input);
            param.Add(name: AuthPackageConstant.V_PASSWORD, createProctorViewModel.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: AuthPackageConstant.V_PHONENUM, createProctorViewModel.Phonenum, dbType: DbType.String, direction: ParameterDirection.Input);
            var res = await _dbContext.Connection.ExecuteAsync(AuthPackageConstant.AUTH_PACKAGE_CREATE_USER, param, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> DeleteUser(int id)
        {
            DynamicParameters param = new();
            param.Add(name: AuthPackageConstant.V_USER_ID, id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add(name: AuthPackageConstant.V_IS_DELETED, dbType: DbType.Int32, direction: ParameterDirection.Output);
            var res = await _dbContext.Connection.ExecuteAsync(AuthPackageConstant.AUTH_PACKAGE_delete_user, param, commandType: CommandType.StoredProcedure);
            int deleted = param.Get<int>(AuthPackageConstant.V_IS_DELETED);
            return deleted;


        }

        public async Task<int> UpdateUserPassword(UpdatePasswordViewModel updateProctorPasswordViewModel)
        {
            DynamicParameters param = new();
            param.Add(name: AuthPackageConstant.V_USER_CREDENTIAL_ID, updateProctorPasswordViewModel.CredentialId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add(name: AuthPackageConstant.V_LAST_PASSWORD, updateProctorPasswordViewModel.LastPassword, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: AuthPackageConstant.V_NEW_PASSWORD, updateProctorPasswordViewModel.NewPassword, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: AuthPackageConstant.V_CONFIRM_PASSWORD, updateProctorPasswordViewModel.ConfirmPassword, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: AuthPackageConstant.V_IS_UPDATED, dbType: DbType.String, direction: ParameterDirection.Output);
            var res = await _dbContext.Connection.ExecuteAsync(AuthPackageConstant.AUTH_PACKAGE_UPDATE_USER_PASSWORD, param, commandType: CommandType.StoredProcedure);
            int updated = param.Get<int>(AuthPackageConstant.V_IS_UPDATED);
            return updated;
        }

        public async Task<UserDataViewModel> GetUserById(int id)
        {
            DynamicParameters param = new();
            param.Add(name: AuthPackageConstant.V_USER_ID, id, dbType: DbType.String, direction: ParameterDirection.Input);
            var res = await _dbContext.Connection.QueryAsync<UserDataViewModel>(AuthPackageConstant.AUTH_PACKAGE_GET_USER_BY_ID, param, commandType: CommandType.StoredProcedure);
            return res.FirstOrDefault()!;
        }

        public async Task<UserDataViewModel> GetUserByCredential(LoginViewModel userCredential)
        {
            DynamicParameters param = new();
            param.Add(name: AuthPackageConstant.V_PASSWORD, userCredential.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: AuthPackageConstant.V_EMAIL, userCredential.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: AuthPackageConstant.V_PHONENUM, userCredential.Phonenum, dbType: DbType.String, direction: ParameterDirection.Input);
            var res = await _dbContext.Connection.QueryAsync<UserDataViewModel>(AuthPackageConstant.AUTH_PACKAGE_USER_LOGIN, param, commandType: CommandType.StoredProcedure);
            return res.FirstOrDefault()!;
        }

        public async Task<int> UpdateName(UpdateNameViewModel update)
        {
            DynamicParameters param = new();
            param.Add(name: AuthPackageConstant.V_USER_ID, update.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add(name: AuthPackageConstant.V_FIRST_NAME, update.FirstName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: AuthPackageConstant.V_LAST_NAME, update.LastName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: AuthPackageConstant.V_PASSWORD, update.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: AuthPackageConstant.V_IS_UPDATED, dbType: DbType.String, direction: ParameterDirection.Output);

            var res = await _dbContext.Connection.ExecuteAsync(AuthPackageConstant.AUTH_PACKAGE_UPDATE_NAME, param, commandType: CommandType.StoredProcedure);
            int updated = param.Get<int>(AuthPackageConstant.V_IS_UPDATED);
            return updated;
        }

        public async Task<int> UpdatePhone(UpdatePhoneViewModel update)
        {
            DynamicParameters param = new();
            param.Add(name: AuthPackageConstant.V_USER_ID, update.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add(name: AuthPackageConstant.V_PHONENUM, update.PhoneNo, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: AuthPackageConstant.V_PASSWORD, update.Password, dbType: DbType.String, direction: ParameterDirection.Input);



            param.Add(name: AuthPackageConstant.V_IS_UPDATED, dbType: DbType.String, direction: ParameterDirection.Output);
            var res = await _dbContext.Connection.ExecuteAsync(AuthPackageConstant.AUTH_PACKAGE_UPDATE_PHONE, param, commandType: CommandType.StoredProcedure);
            int updated = param.Get<int>(AuthPackageConstant.V_IS_UPDATED);
            return updated;
        }

        public async Task<int> UpdateEmail(UpdateEmailViewModel update)
        {
            DynamicParameters param = new();
            param.Add(name: AuthPackageConstant.V_USER_ID, update.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add(name: AuthPackageConstant.V_EMAIL, update.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: AuthPackageConstant.V_PASSWORD, update.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: AuthPackageConstant.V_IS_UPDATED, dbType: DbType.String, direction: ParameterDirection.Output);
            var res = await _dbContext.Connection.ExecuteAsync(AuthPackageConstant.AUTH_PACKAGE_UPDATE_EMAIL, param, commandType: CommandType.StoredProcedure);
            int updated = param.Get<int>(AuthPackageConstant.V_IS_UPDATED);
            return updated;

        }
        public async Task<int> CheckEmailExist(string email)
        {
            DynamicParameters param = new();
            param.Add(name: "v_email", email, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add(name: "email_exists", dbType: DbType.Int32, direction: ParameterDirection.Output);
            var res = await _dbContext.Connection.ExecuteAsync("AUTH_PACKAGE.Check_email", param, commandType: CommandType.StoredProcedure);

            int emailExists = param.Get<int>("email_exists");
            return emailExists;
        }
    }
}
