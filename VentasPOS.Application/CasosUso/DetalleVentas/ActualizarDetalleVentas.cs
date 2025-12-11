using VentasPOS.Application.DTO.DetalleVentas;
using VentasPOS.Application.Interfaces.DetalleVentas;

namespace VentasPOS.Application.CasosUso.DetalleVentas
{
    public class ActualizarDetalleVentas : IActualizarDetalleVentas
    {
        public readonly IDetalleVentasRepository _repo;

        public ActualizarDetalleVentas(IDetalleVentasRepository repo) 
        {
            _repo = repo;
        }    

        public async Task<bool> Handle(int id, DetalleVentaActualizarDto detalleVenta)
        {
            var response = await _repo.Actualizar(id, detalleVenta);
            return response;
        }
    }
}
