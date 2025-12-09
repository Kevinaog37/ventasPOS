using VentasPOS.Application.DTO.Compras;
using VentasPOS.Application.Interfaces.Compras;
using VentasPOS.Domain.Entities;

namespace VentasPOS.Application.CasosUso.Compras
{
    public class CrearCompra : ICrearCompra
    {
        private readonly ICompraRepository _repo;

        public CrearCompra(ICompraRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> Handle(CompraCrearDto request)
        {
            var compra = new Compra { IdUsuarioVendedor = request.IdUsuarioVendedor, IdUsuarioProveedor = request.IdUsuarioProveedor, Estado = request.Estado, Fecha = request.Fecha };
            return await _repo.Insertar(compra);
        }
    }
}
