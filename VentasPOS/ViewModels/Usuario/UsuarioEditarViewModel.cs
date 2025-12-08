using VentasPOS.DTO.Usuario;
using VentasPOS.Services.Usuario;

namespace VentasPOS.ViewModels.Usuario
{
    public class UsuarioEditarViewModel
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioMostrarDto Usuario { get; set; } = new();
        public string Mensaje { get; set; } = string.Empty;
        public string Alerta { get; set; } = string.Empty;


        public UsuarioEditarViewModel(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public async Task Mostrar(int Id)
        {
            var res = await _usuarioService.Mostrar(Id);

            if (res != null)
            {
                Usuario = res;
                
            }
            else
            {
                Alerta = "2";
                Mensaje = "No se encontró el usuario.";
                Usuario = new UsuarioMostrarDto();
            }
            Alerta = "0";
        }

        public async Task Actualizar()
        {
            var res = await _usuarioService.Actualizar(Usuario);
            Console.WriteLine("Resultado " + res);
            if (res)
            {
                Alerta = "1";
                Mensaje = "Usuario actualizado correctamente.";
            }
            else
            {
                Alerta = "2";
                Mensaje = "No se pudo actualizar el usuario.";
            }
            
        }

    }
}
