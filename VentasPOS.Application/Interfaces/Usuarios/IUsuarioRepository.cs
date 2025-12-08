using VentasPOS.Domain.Entities;
namespace VentasPOS.Application.Interfaces.Usuarios
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
