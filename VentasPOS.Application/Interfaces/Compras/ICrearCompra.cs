using VentasPOS.Application.DTO.Compras;

namespace VentasPOS.Application.Interfaces.Compras
{
    public interface ICrearCompra
    {
        Task<int> Handle(CompraCrearDto compraCrearDto);
    }
}
