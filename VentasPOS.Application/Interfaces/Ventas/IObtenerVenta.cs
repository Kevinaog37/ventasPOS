using VentasPOS.Application.DTO.Ventas;

namespace VentasPOS.Application.Interfaces.Ventas
{
    public interface IObtenerVenta
    {
        Task<VentaMostrarDto> Handle(int id);
    }
}
