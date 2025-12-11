using Dapper;
using System.Data;
using VentasPOS.Application.DTO.Auth;
using VentasPOS.Application.Interfaces.Auth;

namespace VentasPOS.Infraestructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IDbConnection _db;

        public AuthRepository(IDbConnection db) {
            _db = db;
        }
        public async Task<LoginResult> Login(LoginRequest login)
        {
            var success = false;
            var usuario = await _db.QueryFirstOrDefaultAsync<LoginResult>("sp_ObtenerUsuarioPorCorreo", new { Correo = login.Correo }, commandType: CommandType.StoredProcedure);

            if (usuario != null) {
                success = BCrypt.Net.BCrypt.Verify(login.Clave, usuario.Clave);
                if (success)
                {
                    return new LoginResult { Id = usuario.Id, IdRol = usuario.IdRol, Token = usuario.Token, Nombre = usuario.Nombre };
                }
            }

            return new LoginResult();
        }
    }
}
