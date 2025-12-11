using VentasPOS.Application.Interfaces.DetalleCompras;

namespace VentasPOS.Application.CasosUso.DetalleCompras
{
    public class EliminarDetalleCompras
    {
        private readonly IDetalleCompraRepository _repo;

        public EliminarDetalleCompras(IDetalleCompraRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(int Id)
        {
            var response = await _repo.Eliminar(Id);
            return response;
        }
    }
}
