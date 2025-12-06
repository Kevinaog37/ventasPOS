using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasPOS.Domain.Entities;

namespace VentasPOS.Application.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> Listar();
        Task<Usuario?> ObtenerPorId(int id);
        Task<int> Crear(Usuario usuario);
        Task<bool> Actualizar(Usuario usuario);
        Task<bool> Eliminar(int id);
    }
}
