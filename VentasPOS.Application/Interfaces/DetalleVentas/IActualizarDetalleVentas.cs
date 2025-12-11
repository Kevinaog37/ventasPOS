using VentasPOS.Application.DTO.DetalleVentas;

namespace VentasPOS.Application.Interfaces.DetalleVentas
{
    public interface IActualizarDetalleVentas
    {
        public Task<bool> Handle(int id, DetalleVentaActualizarDto detalleVenta);
    }
}
