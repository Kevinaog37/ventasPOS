namespace VentasPOS.Application.DTO.Compras
{
    public class CompraActualizarDto
    {
        public int IdUsuarioProveedor { get; set; }
        public int IdUsuarioVendedor { get; set; }
        public DateTime Fecha { get; set; }
        public int Estado { get; set; }
    }
}
