using VentasPOS.Application.DTO.Compras;

namespace VentasPOS.Application.Interfaces.Compras
{
    public interface IInsertarCompraDetalleCompra
    {
        public Task<bool> Handle(CompraDetalleCompraInsertarDto ventaDetalleCompra);
    }
}
