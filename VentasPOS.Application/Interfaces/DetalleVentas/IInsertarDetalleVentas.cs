using VentasPOS.Application.DTO.DetalleVentas;

namespace VentasPOS.Application.Interfaces.DetalleVentas
{
    public interface IInsertarDetalleVentas
    {
        Task<int> Handle(DetalleVentaInsertarDto detalleVenta);
    }
}