namespace VentasPOS.DTO.Usuario
{
    public class UsuarioCrearDto
    {
        public string ?Nombre { get; set; } = string.Empty;
        public string ?Correo { get; set; } = string.Empty;
        public string ?Clave { get; set; } = string.Empty;
        public DateTime ?FechaNacimiento { get; set; }
        public string Rol { get; set; } = string.Empty;
    }
}
