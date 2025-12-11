namespace VentasPOS.Application.DTO.Auth
{
    public class LoginRequest
    {
        public string Correo { get; set; } = string.Empty;
        public string Clave { get; set; } = string.Empty;
    }
}
