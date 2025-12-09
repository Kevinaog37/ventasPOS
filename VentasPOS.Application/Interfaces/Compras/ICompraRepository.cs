using VentasPOS.Application.DTO.Compras;
using VentasPOS.Domain.Entities;
namespace VentasPOS.Application.Interfaces.Compras
{
    public interface ICompraRepository
    {
        Task<IEnumerable<CompraListarDto>> Listar();
        Task<Compra?> ObtenerPorId(int id);
        Task<int> Insertar(Compra venta);
        Task<bool> Actualizar(Compra venta);
        Task<bool> Eliminar(int id);
    }

}