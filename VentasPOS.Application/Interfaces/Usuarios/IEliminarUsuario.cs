using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasPOS.Application.Interfaces.Usuarios
{
    public interface IEliminarUsuario
    {
        public Task<bool> Handle(int id);
    }
}
