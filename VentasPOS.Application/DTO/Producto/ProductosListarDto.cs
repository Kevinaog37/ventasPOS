namespace VentasPOS.Application.DTO.Producto
{
    public class ProductosListarDto
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
