using VentasPOS.Application.DTO.Usuarios;
using VentasPOS.Application.Interfaces.Usuarios;
using VentasPOS.Domain.Entities;

namespace VentasPOS.Application.CasosUso.Usuarios
{
    public class ActualizarUsuario: IActualizarUsuario
    {
        private readonly IUsuarioRepository _repo;

        public ActualizarUsuario(IUsuarioRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(int id, UsuarioActualizarDto dto)
        {
            var usuario = new Usuario {Id = id, Nombre = dto.Nombre, Correo = dto.Correo, FechaNacimiento = dto.FechaNacimiento, IdRol = dto.Rol };
            return await _repo.Actualizar(usuario);
        }
    }
}
