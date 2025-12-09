using VentasPOS.Application.DTO.Compras;

namespace VentasPOS.Application.Interfaces.Compras
{
    public interface IActualizarCompra
    {
        Task<bool> Handle(int Id, CompraActualizarDto compraActualizarDto);
    }
}
