using VentasPOS.Application.DTO.DetalleCompras;

namespace VentasPOS.Application.Interfaces.DetalleCompras
{
    public interface IInsertarDetalleCompras
    {
        Task<int> Handle(DetalleComprasInsertarDto detalleCompra);
    }
}
