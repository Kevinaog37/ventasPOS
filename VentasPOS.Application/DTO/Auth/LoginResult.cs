namespace VentasPOS.Application.DTO.Auth
{
    public class LoginResult
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ?Clave { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public string IdRol { get; set; } = string.Empty;
    }
}
