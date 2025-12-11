using VentasPOS.Application.DTO.DetalleVentas;

namespace VentasPOS.Application.Interfaces.DetalleVentas
{
    public interface IListarDetalleVentas
    {
        Task<IEnumerable<DetalleVentasListarDto>> Handle(int ?IdVenta);
    }
}