using Dapper;
using System.Data;
using VentasPOS.Application.DTO.Compras;
using VentasPOS.Application.Interfaces.Compras;
using VentasPOS.Domain.Entities;


namespace ComprasPOS.Infraestructure.Repositories
{
    public class CompraRepository : ICompraRepository
    {
        private readonly IDbConnection _db;

        public CompraRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<IEnumerable<CompraListarDto>> Listar()
        {
            var res = await _db.QueryAsync<CompraListarDto>("sp_ListarCompras", commandType: CommandType.StoredProcedure);
            return res;
        }

        public async Task<int> Insertar(Compra compra)
        {
            Console.WriteLine(compra.IdUsuarioVendedor);
            Console.WriteLine(compra.IdUsuarioProveedor);
            Console.WriteLine(compra.Fecha);
            Console.WriteLine(compra.Estado);

            try
            {
                return await _db.ExecuteScalarAsync<int>(
                        "sp_InsertarCompra",
                            new
                            {
                                compra.IdUsuarioVendedor,
                                compra.IdUsuarioProveedor,
                                compra.Fecha,
                                compra.Estado
                            },
                            commandType: CommandType.StoredProcedure
                        );
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return -1;
            }

        }

        public async Task<Compra?> ObtenerPorId(int id)
        {
            var sql = $"EXEC dbo.sp_ObtenerCompraPorId {id}";
            return await _db.QueryFirstOrDefaultAsync<Compra>(sql, new { Id = id });
        }

        public async Task<bool> Actualizar(Compra compra)
        {
            try
            {
                var res = await _db.ExecuteAsync(
                            "sp_ActualizarCompra",
                                new
                                {
                                    compra.Id,
                                    compra.IdUsuarioVendedor,
                                    compra.IdUsuarioProveedor,
                                    compra.Fecha,
                                    compra.Estado
                                },
                                commandType: CommandType.StoredProcedure
                            );
                return res > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return false;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                return await _db.ExecuteAsync("sp_EliminarCompra", new { Id = id }, commandType: CommandType.StoredProcedure) > 0;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString()); return false;
            }
        }
    }
}
