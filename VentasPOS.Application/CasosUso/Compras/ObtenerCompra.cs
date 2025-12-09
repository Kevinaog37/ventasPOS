using VentasPOS.Application.DTO.Compras;
using VentasPOS.Application.Interfaces.Compras;

namespace VentasPOS.Application.CasosUso.Compras
{
    public class ObtenerCompra : IObtenerCompra
    {
        private readonly ICompraRepository _repo;
        public ObtenerCompra(ICompraRepository repo)
        {
            _repo = repo;
        }

        public async Task<CompraMostrarDto> Handle(int id)
        {
            CompraMostrarDto res = new CompraMostrarDto();
            try
            {
                var compra = await _repo.ObtenerPorId(id);
                Console.WriteLine("La venta es: " + compra.Id + " | Fecha: " + compra.Fecha);
                return res = new CompraMostrarDto { IdUsuarioVendedor = compra.IdUsuarioVendedor, IdUsuarioProveedor = compra.IdUsuarioProveedor, Estado = compra.Estado, Fecha = compra.Fecha };

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return res;
            }

        }
    }
}
