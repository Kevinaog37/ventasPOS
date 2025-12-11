using VentasPOS.Application.DTO.Usuarios;
using VentasPOS.Application.Interfaces.Usuarios;
using VentasPOS.Domain.Entities;

namespace VentasPOS.Application.CasosUso.Usuarios
{
    public class CrearUsuario: ICrearUsuario
    {
        private readonly IUsuarioRepository _repo;

        public CrearUsuario(IUsuarioRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> Handle(UsuarioCrearDto dto)
        {
            var usuario = new Usuario { Nombre = dto.Nombre,Correo = dto.Correo,Clave = BCrypt.Net.BCrypt.HashPassword(dto.Clave), FechaNacimiento = dto.FechaNacimiento, IdRol = dto.Rol };
            return await _repo.Crear(usuario);
        }
    }
}
