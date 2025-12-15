using VentasPOS.Application.DTO.Venta;

namespace VentasPOS.Application.Interfaces.Ventas
{
    public interface IInsertarVentaDetalleVenta
    {
        public Task<bool> Handle(VentaDetalleVentaInsertarDto ventaDetalleVenta);
    }
}
