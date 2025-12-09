using System.Data;
using Dapper;
using VentasPOS.Application.Interfaces.Ventas;
using VentasPOS.Application.DTO.Ventas;
using VentasPOS.Domain.Entities;


namespace VentasPOS.Infraestructure.Repositories
{
    public class VentaRepository: IVentaRepository
    {
        private readonly IDbConnection _db;

        public VentaRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<IEnumerable<VentaListarDto>> Listar()
        {
            var res = await _db.QueryAsync<VentaListarDto>("sp_ListarVentas", commandType: CommandType.StoredProcedure);
            return res;
        }

        public async Task<int> Insertar(Venta venta)
        {
            Console.WriteLine(venta.IdUsuarioCliente);
            Console.WriteLine(venta.IdUsuarioProveedor);
            Console.WriteLine(venta.Fecha);
            Console.WriteLine(venta.Estado);

            try
            {
                return await _db.ExecuteScalarAsync<int>(
                        "sp_InsertarVenta",
                            new
                            {
                                venta.IdUsuarioCliente,
                                venta.IdUsuarioProveedor,
                                venta.Fecha,
                                venta.Estado
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

        public async Task<Venta?> ObtenerPorId(int id)
        {
            var sql = $"EXEC dbo.sp_ObtenerVentaPorId {id}";
            return await _db.QueryFirstOrDefaultAsync<Venta>(sql, new { Id = id });
        }

        public async Task<bool> Actualizar(Venta venta)
        {
            try
            {
                var res = await _db.ExecuteAsync(
                            "sp_ActualizarVenta",
                                new
                                {
                                    venta.Id,
                                    venta.IdUsuarioCliente,
                                    venta.IdUsuarioProveedor,
                                    venta.Fecha,
                                    venta.Estado
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
                return await _db.ExecuteAsync("sp_EliminarVenta", new { Id = id }, commandType: CommandType.StoredProcedure) > 0;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString()); return false;
            }
        }
    }
}
