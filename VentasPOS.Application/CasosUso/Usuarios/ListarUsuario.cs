using VentasPOS.Application.DTO.Usuarios;
using VentasPOS.Application.Interfaces.Usuarios;
using VentasPOS.Domain.Entities;

namespace VentasPOS.Application.CasosUso.Usuarios
{
    public class ListarUsuario:IListarUsuario
    {
        private readonly IUsuarioRepository _repo;

        public ListarUsuario(IUsuarioRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<UsuarioDto>> Handle()
        {
            var data = await _repo.Listar();
            var res = data.Select(x => new UsuarioDto
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Correo = x.Correo,
                FechaNacimiento = x.FechaNacimiento,
                Rol = x.IdRol
            });

            return res;
        }
    }
}
