using VentasPOS.Application.DTO.DetalleCompras;
using VentasPOS.Application.Interfaces.DetalleCompras;

namespace VentasPOS.Application.CasosUso.DetalleCompras
{
    public class InsertarDetalleCompras : IInsertarDetalleCompras
    {
        private readonly IDetalleCompraRepository _repo;
        public InsertarDetalleCompras(IDetalleCompraRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> Handle(DetalleComprasInsertarDto detalleCompras)
        {
            var response = await _repo.Insertar(detalleCompras);
            return response;
        }
    }
}
