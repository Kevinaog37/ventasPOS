using VentasPOS.Application.DTO.DetalleVentas;
using VentasPOS.Domain.Entities;
namespace VentasPOS.Application.Interfaces.DetalleVentas
{
    public interface IDetalleVentasRepository
    {
        Task<IEnumerable<DetalleVentasListarDto>> Listar(int ?IdVenta);
        Task<int> Insertar(DetalleVentaInsertarDto detalleVenta);
        Task<bool> Actualizar(int IdVenta, DetalleVentaActualizarDto detalleVenta);
        Task<bool> Eliminar(int id);
    }
}
