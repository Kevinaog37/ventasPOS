using VentasPOS.Application.Interfaces.Compras;
using VentasPOS.Application.Interfaces.Usuarios;

namespace VentasPOS.Application.CasosUso.Compras
{
    public class EliminarCompra
    {
        private readonly ICompraRepository _repo;

        public EliminarCompra(ICompraRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(int id)
        {
            return await _repo.Eliminar(id);
        }
    }
}
