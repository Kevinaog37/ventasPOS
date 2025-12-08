using VentasPOS.Application.DTO.Usuarios;

namespace VentasPOS.Application.Interfaces.Usuarios
{
    public interface IActualizarUsuario
    {
        Task<bool> Handle(int id, UsuarioActualizarDto usuarioActualizarDto);
    }
}
