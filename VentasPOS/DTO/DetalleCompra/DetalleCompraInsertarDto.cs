namespace VentasPOS.DTO.DetalleCompra
{
    public class DetalleCompraInsertarDto
    {
        public int IdCompra { get; set; }
        public int IdProducto { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public int Estado { get; set; } = 1;
    }
}
