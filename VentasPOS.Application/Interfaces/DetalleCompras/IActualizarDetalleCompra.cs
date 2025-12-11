
using VentasPOS.Application.DTO.DetalleCompras;

namespace VentasPOS.Application.Interfaces.DetalleCompras
{
    public interface IActualizarDetalleCompra
    {
        Task<bool> Handle(int id, DetalleComprasActualizarDto detalleCompras); 
    }
}
