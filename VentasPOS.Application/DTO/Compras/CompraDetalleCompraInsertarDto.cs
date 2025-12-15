using System.Collections.ObjectModel;
using VentasPOS.Application.DTO.DetalleCompras;

namespace VentasPOS.Application.DTO.Compras
{
    public class CompraDetalleCompraInsertarDto
    {
        public int IdUsuarioVendedor { get; set; }
        public int IdUsuarioProveedor { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int Estado { get; set; } = 1;
        public ObservableCollection<DetalleComprasInsertarDto> DetalleCompra { get; set; } = new();
    }
}
