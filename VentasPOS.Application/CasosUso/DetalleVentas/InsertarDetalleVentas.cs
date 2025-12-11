using VentasPOS.Application.DTO.DetalleVentas;
using VentasPOS.Application.Interfaces.DetalleVentas;

namespace VentasPOS.Application.CasosUso.DetalleVentas
{
    public class InsertarDetalleVentas: IInsertarDetalleVentas
    {
        private readonly IDetalleVentasRepository _repo;

        public InsertarDetalleVentas(IDetalleVentasRepository repo) 
        {
            _repo = repo;
        }

        public async Task<int> Handle(DetalleVentaInsertarDto detalleVenta)
        {
            var response = await _repo.Insertar(detalleVenta);
            return response;
        }
    }
}
