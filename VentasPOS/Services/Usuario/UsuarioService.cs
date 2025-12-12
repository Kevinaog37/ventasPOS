
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using VentasPOS.DTO.Auth;
using VentasPOS.DTO.Usuario;

namespace VentasPOS.Services.Usuario
{
    public class UsuarioService
    {
        private readonly HttpClient _http;

        public UsuarioService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ObservableCollection<UsuarioListarDto>> Listar()
        {
            try
            {
                var usuarios = await _http.GetFromJsonAsync<IEnumerable<UsuarioListarDto>>("Usuarios");
                return new ObservableCollection<UsuarioListarDto>(usuarios ?? Enumerable.Empty<UsuarioListarDto>());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al listar usuarios: {ex.Message}");
                return new ObservableCollection<UsuarioListarDto>();
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