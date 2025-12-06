namespace VentasPOS.DTO.Usuario
{
    public class UsuarioListarDto
    {
        public int Id { get; set; }
        public string ?Nombre { get; set; } 
        public string ?Correo { get; set; }
        public string ?Clave { get; set; }
        public DateTime ?FechaNacimiento { get; set; }
        public string ?Rol { get; set; }
    }
}
