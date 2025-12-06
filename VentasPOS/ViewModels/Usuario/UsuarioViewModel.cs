using VentasPOS.DTO.Usuario;
using VentasPOS.Services.Usuario;
using VentasPOS.Views.Usuarios;

namespace VentasPOS.ViewModels.Usuario
{
    public class UsuarioViewModel
    {
        private readonly UsuarioService _usuarioService;
        public List<UsuarioListarDto> _listaUsuarios = new();

        public uint Id { get; set; }
        public string? Nombre { get; set; } = "Kevin";
        public string? Correo { get; set; } = "Kevin@gmail.com";
        public string? Clave { get; set; } = "12345";
        public DateTime ?FechaNacimiento { get; set; } = DateTime.Now;
        public string? Rol { get; set; } = "1";

        public UsuarioViewModel(UsuarioService usuarioService) {
            _usuarioService = usuarioService;
        }

        public async Task<bool> Insertar()
        {
            var usuarioDto = new UsuarioCrearDto { Nombre = Nombre, Clave = Clave, Correo = Correo, FechaNacimiento = FechaNacimiento, Rol = Rol };
            var created = await _usuarioService.Insertar(usuarioDto);
            return created;
        }

        public async Task Listar()
        {
            _listaUsuarios = await _usuarioService.Listar();
        }
    }
}
