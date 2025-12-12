namespace VentasPOS.DTO.DetalleVenta
{
    public class DetalleVentaInsertarDto
    {
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
        public int Estado { get; set; }

    }
}
