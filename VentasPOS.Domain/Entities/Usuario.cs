namespace VentasPOS.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string ?Correo { get; set; }
        public string ?Clave { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string ?IdRol { get; set; }
    }
}
