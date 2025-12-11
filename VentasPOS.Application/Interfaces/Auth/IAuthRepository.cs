using VentasPOS.Application.DTO.Auth;

namespace VentasPOS.Application.Interfaces.Auth
{
    public interface IAuthRepository
    {
        Task<LoginResult> Login(LoginRequest login);
    }
}
