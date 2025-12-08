
using System.Threading.Tasks;
using System.Net.Http.Json;
using VentasPOS.DTO.Auth;
using System.Net.Http;
using VentasPOS.DTO.Usuario;
using System.Linq.Expressions;

namespace VentasPOS.Services.Usuario
{
    public class UsuarioService
    {
        private readonly HttpClient _http;

        public UsuarioService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<UsuarioListarDto>> Listar()
        {
            try
            {
                var usuarios = await _http.GetFromJsonAsync<IEnumerable<UsuarioListarDto>>("Usuarios");
                return usuarios?.ToList() ?? new List<UsuarioListarDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<UsuarioListarDto>();
            }
        }

        public async Task<UsuarioMostrarDto> Mostrar(int id)
        {
            try
            {
                var usuario = await _http.GetFromJsonAsync<UsuarioMostrarDto>($"Usuarios/mostrar/{id}");
                //var usuario = new UsuarioActualizarDto { Id = 1, Correo = "Prueba@hmail.com", FechaNacimiento = DateTime.Now, Nombre = "PruebaK", Rol = "3" };
                return usuario;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new UsuarioMostrarDto();
            }
        }

        public async Task<bool> Insertar(UsuarioCrearDto request)
        {
            var response = await _http.PostAsJsonAsync("Usuarios", request);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Actualizar(UsuarioMostrarDto request)
        {
            UsuarioActualizarDto usuarioActualizar = new UsuarioActualizarDto { Id = request.Id, Nombre = request.Nombre, Correo = request.Correo, FechaNacimiento = request.FechaNacimiento, Rol = request.Rol };

            var response = await _http.PatchAsJsonAsync($"Usuarios/actualizar/{request.Id}", usuarioActualizar);
            return await response.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<bool> Eliminar(int id)
        {
            var response = await _http.DeleteFromJsonAsync<bool>($"Usuarios/eliminar/{id}");
            return response;
        }
    }
}