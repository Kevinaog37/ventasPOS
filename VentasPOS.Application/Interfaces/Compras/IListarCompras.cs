using VentasPOS.Application.DTO.Compras;

namespace VentasPOS.Application.Interfaces.Compras
{
    public interface IListarCompras
    {
        public Task<IEnumerable<CompraListarDto>> Handle();
    }
}
