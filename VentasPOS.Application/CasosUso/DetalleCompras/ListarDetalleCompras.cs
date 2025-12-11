using VentasPOS.Application.DTO.DetalleCompras;
using VentasPOS.Application.Interfaces.DetalleCompras;
using VentasPOS.Domain.Entities;

namespace VentasPOS.Application.CasosUso.DetalleCompras
{
    public class ListarDetalleCompras : IListarDetalleCompras
    {
        private readonly IDetalleCompraRepository _repo;
        public ListarDetalleCompras(IDetalleCompraRepository repo) { 
            _repo= repo;
        }
        public async Task<IEnumerable<DetalleComprasListarDto>> Handle(int ? IdCompra)
        {
            var response = await _repo.Listar(IdCompra);
            return response;
        }
    }
}
