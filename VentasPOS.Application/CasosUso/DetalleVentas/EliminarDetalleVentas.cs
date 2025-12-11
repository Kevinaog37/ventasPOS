using VentasPOS.Application.Interfaces.DetalleVentas;

namespace VentasPOS.Application.CasosUso.DetalleVentas
{
    public class EliminarDetalleVentas
    {
        private readonly IDetalleVentasRepository _repo;
        public EliminarDetalleVentas(IDetalleVentasRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(int Id)
        {
            var response = await _repo.Eliminar(Id);
            return response;
        }
    }
}
