using VentasPOS.Application.DTO.Ventas;
using VentasPOS.Application.Interfaces.Ventas;


namespace VentasPOS.Application.CasosUso.Ventas
{
    public class ListarVentas: IListarVentas
    {
        private readonly IVentaRepository _repo;

        public ListarVentas(IVentaRepository repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<VentaListarDto>> Handle()
        {
            return await _repo.Listar();
        }
    }
}
