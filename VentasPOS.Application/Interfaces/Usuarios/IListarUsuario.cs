using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasPOS.Application.DTO.Usuarios;

namespace VentasPOS.Application.Interfaces.Usuarios
{
    public interface IListarUsuario
    {
        public Task<IEnumerable<UsuarioDto>> Handle();
    }
}
