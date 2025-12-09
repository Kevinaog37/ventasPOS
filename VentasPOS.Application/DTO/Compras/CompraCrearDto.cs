namespace VentasPOS.Application.DTO.Compras
{
    public class CompraCrearDto
    {
        public int IdUsuarioProveedor { get; set; }
        public int IdUsuarioVendedor { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int Estado { get; set; } = 1;
    }
}
