namespace VentasPOS.Application.DTO.Ventas
{
    public class VentaListarDto
    {
        public int Id {  get; set; }
        public int IdUsuarioCliente { get; set; }
        public int IdUsuarioProveedor { get; set; }
        public int NombreCliente { get; set; }
        public int NombreProveedor { get; set; }
        public DateTime Fecha { get; set; }
        public int Estado { get; set; }
        public decimal Valor {  get; set; }

    }
}
