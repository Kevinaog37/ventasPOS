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
            return await _db.QueryAsync<VentaListarDto>("sp_ListarVentas", commandType: CommandType.StoredProcedure);
        }
    }
}
