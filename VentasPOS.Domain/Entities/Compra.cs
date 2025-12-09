using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasPOS.Domain.Entities
{
    public class Compra
    {
        public int Id { get; set; }
        public int IdUsuarioProveedor { get; set; }
        public int IdUsuarioVendedor { get; set; }
        public DateTime Fecha { get; set; }
        public int Estado { get; set; }
    }
}
