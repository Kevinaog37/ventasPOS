using System.Collections.ObjectModel;
using VentasPOS.DTO.DetalleVenta;

namespace VentasPOS.DTO.Venta
{
    public class VentaDetalleVentaInsertarDto
    {
        public int IdUsuarioCliente { get; set; }
        public int IdUsuarioProveedor { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int Estado { get; set; } = 1;
        public ObservableCollection<DetalleVentaInsertarDto> DetalleVenta { get; set; } = new();
    }
}
