using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasPOS.Application.DTO.Compras
{
    public class CompraMostrarDto
    {
        public int IdUsuarioVendedor { get; set; }
        public int IdUsuarioProveedor { get; set; }
        public DateTime Fecha { get; set; }
        public int Estado { get; set; }
    }
}
