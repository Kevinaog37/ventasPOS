using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasPOS.Application.Interfaces.Ventas
{
    public interface IEliminarVenta
    {
        public Task<bool> Handle(int id);
    }
}
