namespace VentasPOS.Services.Auth
{
    public class UserSessionService
    {
        public string Username { get; private set; } = string.Empty;
        public void SetUser(string username)
        {
            Username = username;
        }

        public void Clear()
        {
            Username = string.Empty;
        }

        public bool IsLoggedIn() => !string.IsNullOrEmpty(Username);
    }
}
