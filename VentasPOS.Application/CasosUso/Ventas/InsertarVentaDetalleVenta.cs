using VentasPOS.Application.DTO.Venta;
using VentasPOS.Application.Interfaces.Ventas;

namespace VentasPOS.Application.CasosUso.Ventas
{
    public class InsertarVentaDetalleVenta : IInsertarVentaDetalleVenta
    {
        private readonly IVentaRepository _repo;
        
        public InsertarVentaDetalleVenta(IVentaRepository repo)
        {
            _repo = repo;
        }
        
        public async Task<bool> Handle(VentaDetalleVentaInsertarDto ventaDetalleVenta)
        {
            return await _repo.InsertarVentaDetalleVenta(ventaDetalleVenta);
        }
    }
}
