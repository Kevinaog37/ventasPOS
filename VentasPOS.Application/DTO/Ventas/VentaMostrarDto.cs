using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasPOS.Application.DTO.Ventas
{
    public class VentaMostrarDto
    {
        public int IdUsuarioCliente { get; set; }
        public int IdUsuarioProveedor { get; set; }
        public DateTime Fecha { get; set; }
        public int Estado { get; set; }
    }
}
