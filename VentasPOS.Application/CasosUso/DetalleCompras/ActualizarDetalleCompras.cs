using VentasPOS.Application.DTO.DetalleCompras;
using VentasPOS.Application.Interfaces.DetalleCompras;

namespace VentasPOS.Application.CasosUso.DetalleCompras
{
    public class ActualizarDetalleCompras : IActualizarDetalleCompra
    {
        private readonly IDetalleCompraRepository _repo;

        public ActualizarDetalleCompras(IDetalleCompraRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(int id, DetalleComprasActualizarDto detalleCompra)
        {
            var response = await _repo.Actualizar(id, detalleCompra);
            return response;
        }
    }
}
