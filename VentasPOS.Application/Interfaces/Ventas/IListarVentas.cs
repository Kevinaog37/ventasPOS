using VentasPOS.Application.DTO.Ventas;

namespace VentasPOS.Application.Interfaces.Ventas
{
    public interface IListarVentas
    {
        public Task<IEnumerable<VentaListarDto>> Handle();
    }
}
