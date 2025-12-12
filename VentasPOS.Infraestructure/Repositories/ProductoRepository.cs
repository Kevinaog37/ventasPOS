using Dapper;
using System.Data;
using VentasPOS.Application.DTO.Producto;
using VentasPOS.Application.Interfaces.Producto;

namespace VentasPOS.Infraestructure.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly IDbConnection _db;

        public ProductoRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<IEnumerable<ProductosListarDto>> Listar()
        {
            var response = await _db.QueryAsync<ProductosListarDto>("sp_ListarProductos", commandType: CommandType.StoredProcedure);
            return response;
        }
    }
}
