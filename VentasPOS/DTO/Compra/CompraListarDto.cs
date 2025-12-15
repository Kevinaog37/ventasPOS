namespace VentasPOS.DTO.Compra
{
    public class CompraListarDto
    {
        public int Id { get; set; }
        public int IdUsuarioVendedor { get; set; }
        public int IdUsuarioProveedor { get; set; }
        public string NombreVendedor { get; set; }
        public string NombreProveedor { get; set; }
        public DateTime Fecha { get; set; }
        public int Estado { get; set; }
    }
}
