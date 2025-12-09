using VentasPOS.Application.DTO.Ventas;

using VentasPOS.Application.Interfaces.Ventas;
using VentasPOS.Domain.Entities;

namespace VentasPOS.Application.CasosUso.Ventas
{
    public class CrearVenta: ICrearVenta
    {
        private readonly IVentaRepository _repo;

        public CrearVenta(IVentaRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> Handle(VentaCrearDto request )
        {
            var venta = new Venta { IdUsuarioCliente = request.IdUsuarioCliente, IdUsuarioProveedor = request.IdUsuarioProveedor, Estado = request.Estado, Fecha = request.Fecha };
            return await _repo.Insertar(venta);
        }
    }
}
