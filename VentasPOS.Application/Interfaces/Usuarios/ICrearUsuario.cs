using VentasPOS.Application.DTO.Usuarios;

namespace VentasPOS.Application.Interfaces.Usuarios
{
    public interface ICrearUsuario
    {
        Task<int> Handle(UsuarioCrearDto usuarioCrearDto);
    }
}
