using VentasPOS.Application.DTO.Compras;

namespace VentasPOS.Application.Interfaces.Compras
{
    public interface IObtenerCompra
    {
        Task<CompraMostrarDto> Handle(int id);
    }
}
