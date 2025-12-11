using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasPOS.Application.Interfaces.Usuarios;

namespace VentasPOS.Application.CasosUso.Usuarios
{
    public class EliminarUsuario : IEliminarUsuario
    {
        private readonly IUsuarioRepository _repo;

        public EliminarUsuario(IUsuarioRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(int id)
        {
            return await _repo.Eliminar(id);
        }
    }
}
