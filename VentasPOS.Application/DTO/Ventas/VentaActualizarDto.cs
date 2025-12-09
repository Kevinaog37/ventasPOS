namespace VentasPOS.Application.DTO.Ventas
{
    public class VentaActualizarDto
    {
        public int IdUsuarioCliente { get; set; }
        public int IdUsuarioProveedor { get; set; }
        public DateTime Fecha { get; set; }
        public int Estado { get; set; }
    }
}
