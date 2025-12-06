
using System.Threading.Tasks;
using System.Net.Http.Json;
using VentasPOS.DTO.Auth;
using System.Net.Http;
using VentasPOS.DTO.Usuario;

namespace VentasPOS.Services.Usuario
{
    public class UsuarioService
    {
        private readonly HttpClient _http;

        public UsuarioService(HttpClient http) { 
            _http = http;
        }

        public async Task<bool> Insertar(UsuarioCrearDto request)
        {
            var response = await _http.PostAsJsonAsync("https://localhost:7295/api/Usuarios/", request);

            return response.IsSuccessStatusCode;
        }

        public async Task<List<UsuarioListarDto>> Listar()
        {
            try
            {
                var usuarios = await _http.GetFromJsonAsync<IEnumerable<UsuarioListarDto>>("https://localhost:7295/api/Usuarios");
                
                return usuarios?.ToList() ?? new List<UsuarioListarDto>();
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
                return new List<UsuarioListarDto>();
            }
        }
    }
}