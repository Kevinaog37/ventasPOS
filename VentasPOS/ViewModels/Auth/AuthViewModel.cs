using System.Reflection.Metadata.Ecma335;
using VentasPOS.DTO.Auth;
using VentasPOS.Services.Auth;

namespace VentasPOS.ViewModels.Auth
{
    public class AuthViewModel
    {
        private readonly AuthService _authService;
        public LoginRequest LoginRequest { get; set; } = new LoginRequest();
        public string mensaje = "";
        public AuthViewModel(AuthService authService)
        {
            _authService = authService;
        }

        public async Task<bool> validarSesion()
        {
            return await _authService.EstaLogueado();
        }

        public async Task<bool> IniciarSesion()
        {
            var response = await _authService.Login(LoginRequest);
            if (response)
            {
                LoginRequest = new();
                mensaje = "";
            }
            else
            {
                mensaje = "Correo o contraseña incorrectos.";
            }

                
            return response;
        }
    }
}
