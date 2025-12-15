using VentasPOS.Application.DTO.Venta;
using VentasPOS.Application.DTO.Ventas;
using VentasPOS.Domain.Entities;
namespace VentasPOS.Application.Interfaces.Ventas
{
    public interface IVentaRepository
    {
        Task<IEnumerable<VentaListarDto>> Listar();
        Task<Venta?> ObtenerPorId(int id);
        Task<int> Insertar(Venta venta);
        Task<bool> InsertarVentaDetalleVenta(VentaDetalleVentaInsertarDto ventaDetalleVenta);
        Task<bool> Actualizar(Venta venta);
        Task<bool> Eliminar(int id);
    }

}

