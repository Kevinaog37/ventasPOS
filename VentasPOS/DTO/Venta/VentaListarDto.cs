namespace VentasPOS.DTO.Venta
{
    public class VentaListarDto
    {
        public int Id { get; set; }
        public int IdUsuarioCliente { get; set; }
        public int IdUsuarioProveedor { get; set; }
        public string NombreCliente { get; set; }
        public string NombreProveedor { get; set; }
        public DateTime Fecha { get; set; }
        public int Estado { get; set; }
    }
}
