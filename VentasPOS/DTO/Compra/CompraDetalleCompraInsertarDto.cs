using System.Collections.ObjectModel;
using VentasPOS.DTO.DetalleCompra;

namespace VentasPOS.DTO.Compra
{
    public class CompraDetalleCompraInsertarDto
    {
        public int IdUsuarioVendedor { get; set; }
        public int IdUsuarioProveedor { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int Estado { get; set; } = 1;
        public ObservableCollection<DetalleCompraInsertarDto> DetalleCompra { get; set; } = new();
    }
}
