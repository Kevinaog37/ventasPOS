using VentasPOS.DTO.Usuario;
using VentasPOS.Services.Usuario;

namespace VentasPOS.ViewModels.Usuario
{
    public class UsuarioCrearViewModel
    {
        private readonly UsuarioService _service;
        public UsuarioCrearDto Usuario { get; set; } = new();
        public string Mensaje { get; set; } = "";

        public UsuarioCrearViewModel(UsuarioService service)
        {
            _service = service;
        }

        public async Task Guardar()
        {
            var res = await _service.Insertar(Usuario);

            if (res)
            {
                Mensaje = "Usuario creado correctamente.";
                Usuario = new UsuarioCrearDto();
            }
            else
            {
                Mensaje = "No se pudo crear el usuario.";
            }
        }
    }
}
