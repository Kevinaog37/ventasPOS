using VentasPOS.Application.DTO.Compras;
using VentasPOS.Application.Interfaces.Compras;
using VentasPOS.Domain.Entities;

namespace VentasPOS.Application.CasosUso.Compras
{
    public class ActualizarCompra : IActualizarCompra
    {
        private readonly ICompraRepository _repo;

        public ActualizarCompra(ICompraRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(int Id, CompraActualizarDto request)
        {
            var compra = new Compra { Id = Id, IdUsuarioVendedor = request.IdUsuarioVendedor, IdUsuarioProveedor = request.IdUsuarioProveedor, Estado = request.Estado, Fecha = request.Fecha };
            return await _repo.Actualizar(compra);
        }
    }
}