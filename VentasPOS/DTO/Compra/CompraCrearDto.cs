namespace VentasPOS.DTO.Compra
{
    public class CompraCrearDto
    {
        public int IdUsuarioVendedor { get; set; }
        public int IdUsuarioProveedor { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int Estado { get; set; } = 1;
    }
}
