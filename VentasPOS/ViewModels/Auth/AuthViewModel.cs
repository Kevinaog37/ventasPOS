using VentasPOS.DTO.Auth;
using VentasPOS.Services.Auth;

namespace VentasPOS.ViewModels.Auth
{
    public class AuthViewModel
    {
        private readonly AuthService _authService;
        private readonly UserSessionService _userSession;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public bool IsLoginSuccessful { get; private set; } = false;

        public AuthViewModel(AuthService authService, UserSessionService userSession)
        {
            _authService = authService;
            _userSession = userSession;
        }

        public async Task<bool> Login()
        {
            var request = new LoginRequest { Username = Username, Password = Password };
            IsLoginSuccessful = await _authService.Login(request);

            if (IsLoginSuccessful)
            {
                _userSession.SetUser(Username);
            }

            return IsLoginSuccessful;
        }
    }
}
