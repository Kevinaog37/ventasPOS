namespace VentasPOS.DTO.DetalleVenta
{
    public class DetalleVentaActualizarDto
    {
        public int IdProducto { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public int Estado { get; set; }
    }
}
