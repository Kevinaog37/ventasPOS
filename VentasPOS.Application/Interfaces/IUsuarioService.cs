using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasPOS.Application.DTO;

namespace VentasPOS.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDto>> Listar();
        Task<UsuarioDto?> ObtenerPorId(int id);
        Task<int> Crear(UsuarioCrearDto dto);
        Task<bool> Actualizar(int id, UsuarioCrearDto dto);
        Task<bool> Eliminar(int id);
    }
}
