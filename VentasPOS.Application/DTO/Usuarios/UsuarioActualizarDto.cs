namespace VentasPOS.Application.DTO.Usuarios
{
    public class UsuarioActualizarDto
    {
        public int? Id { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string? Rol { get; set; }
    }
}
