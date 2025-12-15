namespace VentasPOS.DTO.Venta
{
    public class VentaCrearDto
    {
        public int IdUsuarioCliente { get; set; } = 0;
        public int IdUsuarioProveedor { get; set; } = 0;
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int Estado { get; set; } = 1;
    }
}
