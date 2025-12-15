namespace VentasPOS.DTO.DetalleVenta
{
    public class DetalleVentaListarDto
    {
        public int Id { get; set; }
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
        public int Estado { get; set; } = 1;
    }
}
