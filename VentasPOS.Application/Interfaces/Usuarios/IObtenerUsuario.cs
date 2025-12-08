using VentasPOS.Application.DTO.Usuarios;

namespace VentasPOS.Application.Interfaces.Usuarios
{
    public interface IObtenerUsuario
    {
        Task<UsuarioMostrarDto> Handle(int id);
    }
}
