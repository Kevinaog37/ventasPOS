using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasPOS.Application.DTO.DetalleCompras
{
    public class DetalleComprasInsertarDto
    {
        public int IdCompra { get; set; }
        public int IdProducto { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public int Estado { get; set; }
    }
}
