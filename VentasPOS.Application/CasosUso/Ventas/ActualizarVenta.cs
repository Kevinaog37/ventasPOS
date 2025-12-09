using VentasPOS.Application.DTO.Ventas;

using VentasPOS.Application.Interfaces.Ventas;
using VentasPOS.Domain.Entities;

namespace VentasPOS.Application.CasosUso.Ventas
{
    public class ActualizarVenta : IActualizarVenta
    {
        private readonly IVentaRepository _repo;

        public ActualizarVenta(IVentaRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(int Id, VentaActualizarDto request)
        {
            var venta = new Venta { Id = Id, IdUsuarioCliente = request.IdUsuarioCliente, IdUsuarioProveedor = request.IdUsuarioProveedor, Estado = request.Estado, Fecha = request.Fecha };
            return await _repo.Actualizar(venta);
        }
    }
}
