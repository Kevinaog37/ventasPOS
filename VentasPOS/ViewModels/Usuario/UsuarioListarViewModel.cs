using System.Collections.ObjectModel;
using VentasPOS.DTO.Usuario;
using VentasPOS.Services.Usuario;
using VentasPOS.Views.Usuarios;

namespace VentasPOS.ViewModels.Usuario
{
    public class UsuarioListarViewModel
    {
        private readonly UsuarioService _usuarioService;
        public ObservableCollection<UsuarioListarDto> _listaUsuarios = new();

        public UsuarioListarViewModel(UsuarioService usuarioService) {
            _usuarioService = usuarioService;
        }

        public async Task Listar()
        {
            _listaUsuarios = await _usuarioService.Listar();
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _usuarioService.Eliminar(id);
        }
    }
}
