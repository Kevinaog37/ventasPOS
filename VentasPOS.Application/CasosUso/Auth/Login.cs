using VentasPOS.Application.DTO.Auth;
using VentasPOS.Application.Interfaces.Auth;

namespace VentasPOS.Application.CasosUso.Auth
{
    public class Login
    {
        private readonly IAuthRepository _repo;

        public Login(IAuthRepository repo)
        {
            _repo = repo;
        }
        public async Task<LoginResult> Handle(LoginRequest login)
        {
            return await _repo.Login(login);
        }
    }
}
