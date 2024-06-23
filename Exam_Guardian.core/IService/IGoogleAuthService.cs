using Exam_Guardian.core.DTO;

namespace Exam_Guardian.core.IService
{
    public interface IGoogleAuthService
    {
        string GetAuthenticationUri();
        Task AuthenticateAsync();
    }
}


