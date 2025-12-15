namespace VentasPOS.Domain.Entities
{
    public class Producto
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int? IdUsuarioProveedor { get; set; }
    }
}
