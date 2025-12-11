namespace VentasPOS.Application.DTO.DetalleCompras
{
    public class DetalleComprasListarDto
    {
        public int Id {  get; set; }
        public int IdCompra {  get; set; }
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public int Estado { get; set; }
    }
}
