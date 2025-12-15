using VentasPOS.Application.DTO.Compras;
using VentasPOS.Application.Interfaces.Compras;

namespace VentasPOS.Application.CasosUso.Compras
{
    public class InsertarCompraDetalleCompra : IInsertarCompraDetalleCompra
    {
        private readonly ICompraRepository _repo;

        public InsertarCompraDetalleCompra(ICompraRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(CompraDetalleCompraInsertarDto compraDetalleCompra)
        {
            return await _repo.InsertarCompraDetalleCompra(compraDetalleCompra);
        }
    }
}
