namespace VentasPOS.DTO.Venta
{
    public class VentaCrearDto
    {
        public int IdUsuarioCliente { get; set; }
        public int IdUsuarioProveedor { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int Estado { get; set; } = 1;
    }
}
