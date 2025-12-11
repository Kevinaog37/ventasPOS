using VentasPOS.Application.DTO.DetalleCompras;

namespace VentasPOS.Application.Interfaces.DetalleCompras
{
    public interface IDetalleCompraRepository
    {
        Task<int> Insertar(DetalleComprasInsertarDto detalleCompras);
        Task<bool> Actualizar(int Id, DetalleComprasActualizarDto detalleCompras);
        Task<IEnumerable<DetalleComprasListarDto>> Listar(int ?IdCompra);
        Task<bool> Eliminar(int Id);
    }
}
