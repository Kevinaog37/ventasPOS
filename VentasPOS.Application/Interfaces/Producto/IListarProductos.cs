using VentasPOS.Application.DTO.Producto;

namespace VentasPOS.Application.Interfaces.Producto
{
    public interface IListarProductos
    {
        public Task<IEnumerable<ProductosListarDto>> Handle();
    }
}
