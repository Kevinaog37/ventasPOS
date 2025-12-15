using System.ComponentModel.DataAnnotations;

namespace VentasPOS.Application.DTO.DetalleVentas
{
    public class DetalleVentasListarDto
    {
        public int Id { get; set; }
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public int Estado { get; set; }
    }
}
