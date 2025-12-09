using VentasPOS.Application.DTO.Compras;
using VentasPOS.Application.Interfaces.Compras;


namespace VentasPOS.Application.CasosUso.Compras
{
    public class ListarCompras : IListarCompras
    {
        private readonly ICompraRepository _repo;

        public ListarCompras(ICompraRepository repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<CompraListarDto>> Handle()
        {
            return await _repo.Listar();
        }
    }
}
