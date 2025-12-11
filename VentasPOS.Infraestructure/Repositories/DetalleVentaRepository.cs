using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using VentasPOS.Application.DTO.DetalleVentas;
using VentasPOS.Application.Interfaces.DetalleVentas;
using VentasPOS.Domain.Entities;

namespace VentasPOS.Infraestructure.Repositories
{
    public class DetalleVentaRepository : IDetalleVentasRepository

    {
        private readonly IDbConnection _db;

        public DetalleVentaRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<IEnumerable<DetalleVentasListarDto>> Listar(int? IdVenta)
        {
            var response = await _db.QueryAsync<DetalleVentasListarDto>("sp_ListarDetalleVentas", new {IdVenta = IdVenta },
        commandType: CommandType.StoredProcedure);
            return response;
        }

        public async Task<int> Insertar(DetalleVentaInsertarDto detalleVenta)
        {
            var response = await _db.ExecuteScalarAsync<int>("sp_InsertarDetalleVentas",
                                                            new
                                                            {
                                                                IdVenta = detalleVenta.IdVenta,
                                                                IdProducto = detalleVenta.IdProducto,
                                                                Cantidad = detalleVenta.Cantidad,
                                                                Estado = detalleVenta.Estado
                                                            }, commandType: CommandType.StoredProcedure);

            return response;
        }

        public async Task<bool> Actualizar(int id, DetalleVentaActualizarDto detalleVenta)
        {
            var response = await _db.ExecuteAsync("sp_ActualizarDetalleVentas", new { Id = id, 
                                                                                      IdProducto = detalleVenta.IdProducto, Cantidad = detalleVenta.Cantidad,
                                                                                      Estado = detalleVenta.Estado }, 
                                                                                      commandType: CommandType.StoredProcedure
                                                                                      );
            return response > 0;
        }

        public async Task<bool> Eliminar(int id)
        {
            var response = await _db.ExecuteAsync("sp_EliminarDetalleVentas", new { Id = id }, commandType: CommandType.StoredProcedure);
            return response > 0;
        }
    }
}
