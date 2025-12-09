using VentasPOS.Application.DTO.Usuarios;
using VentasPOS.Application.Interfaces.Usuarios;

namespace VentasPOS.Application.CasosUso.Usuarios
{
    public class ObtenerUsuario: IObtenerUsuario
    {
        private readonly IUsuarioRepository _repo;
        public ObtenerUsuario(IUsuarioRepository repo)
        {
            _repo = repo;
        }

        public async Task<UsuarioMostrarDto> Handle(int id)
        {
            UsuarioMostrarDto res = new UsuarioMostrarDto();
            try
            {
                var usuario = await _repo.ObtenerPorId(id);
                Console.WriteLine("Correo del usaur " + usuario.Correo);
                return res = new UsuarioMostrarDto {Id = id, Nombre = usuario.Nombre, Correo = usuario.Correo, FechaNacimiento = usuario.FechaNacimiento, Rol = usuario.IdRol };

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); 
                return res;
            }

        }
    }
}
