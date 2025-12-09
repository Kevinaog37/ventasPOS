using VentasPOS.Application.DTO.Usuarios;
using VentasPOS.Application.DTO.Ventas;
using VentasPOS.Application.Interfaces.Ventas;

namespace VentasPOS.Application.CasosUso.Usuarios
{
    public class ObtenerVenta : IObtenerVenta
    {
        private readonly IVentaRepository _repo;
        public ObtenerVenta(IVentaRepository repo)
        {
            _repo = repo;
        }

        public async Task<VentaMostrarDto> Handle(int id)
        {
            VentaMostrarDto res = new VentaMostrarDto();
            try
            {
                var venta = await _repo.ObtenerPorId(id);
                Console.WriteLine("La venta es: " + venta.Id + " | Fecha: " + venta.Fecha);
                return res = new VentaMostrarDto { IdUsuarioCliente = venta.IdUsuarioCliente, IdUsuarioProveedor = venta.IdUsuarioProveedor, Estado = venta.Estado, Fecha = venta.Fecha};

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); 
                return res;
            }

        }
    }
}
