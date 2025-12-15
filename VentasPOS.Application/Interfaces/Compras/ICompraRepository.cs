using VentasPOS.Application.DTO.Compras;
using VentasPOS.Application.DTO.Venta;
using VentasPOS.Domain.Entities;
namespace VentasPOS.Application.Interfaces.Compras
{
    public interface ICompraRepository
    {
        Task<IEnumerable<CompraListarDto>> Listar();
        Task<Compra?> ObtenerPorId(int id);
        Task<int> Insertar(Compra compra);
        Task<bool> InsertarCompraDetalleCompra(CompraDetalleCompraInsertarDto compraDetalleCompra);
        Task<bool> Actualizar(Compra compra);
        Task<bool> Eliminar(int id);
    }

}