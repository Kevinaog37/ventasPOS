using VentasPOS.Application.DTO.Ventas;

namespace VentasPOS.Application.Interfaces.Ventas
{
    public interface ICrearVenta
    {
        Task<int> Handle(VentaCrearDto usuarioCrearDto);
    }
}
