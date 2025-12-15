namespace VentasPOS.Application.DTO.DetalleVentas
{
    public class DetalleVentaInsertarDto
    {
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public int Estado { get; set; }

    }
}
