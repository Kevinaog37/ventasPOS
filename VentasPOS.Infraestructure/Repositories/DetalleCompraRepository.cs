using Dapper;
using System;
using System.Data;
using VentasPOS.Application.DTO.DetalleCompras;
using VentasPOS.Application.Interfaces.DetalleCompras;
using VentasPOS.Domain.Entities;

namespace VentasPOS.Infraestructure.Repositories
{
    public class DetalleCompraRepository : IDetalleCompraRepository
    {
        private readonly IDbConnection _db;

        public DetalleCompraRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<IEnumerable<DetalleComprasListarDto>> Listar(int? IdCompra)
        {
            var response = await _db.QueryAsync<DetalleComprasListarDto>("sp_ListarDetalleCompras", new { IdCompra = IdCompra }, commandType: CommandType.StoredProcedure);
            return response;
        }

        public async Task<int> Insertar(DetalleComprasInsertarDto detalleCompra)
        {
            var response = await _db.ExecuteScalarAsync<int>("sp_InsertarDetalleCompra", new
            {
                IdCompra = detalleCompra.IdCompra,
                IdProducto = detalleCompra.IdProducto,
                Precio = detalleCompra.Precio,
                Cantidad = detalleCompra.Cantidad,
                Fecha = detalleCompra.Fecha,
                Estado = detalleCompra.Estado
            }, commandType: CommandType.StoredProcedure);
            return response;
        }

        public async Task<bool> Actualizar(int Id, DetalleComprasActualizarDto detalleCompra)
        {
            var response = await _db.ExecuteAsync("sp_ActualizarDetalleCompras", new { Id = Id, IdProducto = detalleCompra.IdProducto, Precio = detalleCompra.Precio, Cantidad = detalleCompra.Cantidad, Fecha = detalleCompra.Fecha, Estado = detalleCompra.Estado }, commandType: CommandType.StoredProcedure);
            return response > 0;
        }

        public async Task<bool> Eliminar(int Id)
        {
            var response = await _db.ExecuteAsync("sp_EliminarDetalleCompras", new { Id = Id }, commandType: CommandType.StoredProcedure);
            return response > 0;
        }
    }
}
