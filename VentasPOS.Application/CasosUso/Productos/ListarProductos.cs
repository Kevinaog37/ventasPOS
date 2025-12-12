using VentasPOS.Application.DTO.Producto;
using VentasPOS.Application.Interfaces.Producto;

namespace VentasPOS.Application.CasosUso.Productos
{
    public class ListarProductos : IListarProductos
    {
        private readonly IProductoRepository _repo;

        public ListarProductos(IProductoRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ProductosListarDto>> Handle()
        {
            var response = await _repo.Listar();
            return response;
        }
    }
}
