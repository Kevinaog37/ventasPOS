namespace VentasPOS.DTO.Producto
{
    public class ProductoListarDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int? IdUsuarioProveedor { get; set; }
        public string? NombreProveedor { get; set; }
    }
}
