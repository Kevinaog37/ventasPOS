using VentasPOS.Application.DTO.Ventas;

namespace VentasPOS.Application.Interfaces.Ventas
{
    public interface IActualizarVenta
    {
        Task<bool> Handle(int Id, VentaActualizarDto ventaActualizarDto);
    }
}
