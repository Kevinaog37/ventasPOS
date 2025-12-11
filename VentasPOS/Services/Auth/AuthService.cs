using Blazored.LocalStorage;
using System.Net.Http.Json;
using VentasPOS.DTO.Auth;

namespace VentasPOS.Services.Auth
{
    public class AuthService
    {
        private readonly HttpClient _http;
        private readonly ILocalStorageService _localStorage;
        private string _message = string.Empty;
        public AuthService(HttpClient http, ILocalStorageService localStorage)
        {
            _http = http;
            _localStorage = localStorage;
        }

        public async Task<bool> Login(LoginRequest request)
        {
            var response = await _http.PostAsJsonAsync("auth", request);

            if (!response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var body = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(json);
                string mensaje = body["message"];
                _message = mensaje;
                return false;
            }

            var data = await response.Content.ReadFromJsonAsync<LoginResult>();
            await _localStorage.SetItemAsync("token", data.Token);
            await _localStorage.SetItemAsync("nombre", data.Nombre);
            await _localStorage.SetItemAsync("idUsuario", data.Id);
            await _localStorage.SetItemAsync("rol", data.Id);
            
            return true;
        }

        public async Task<bool> EstaLogueado()
        {
            var token = await _localStorage.GetItemAsync<string>("token");
            return !string.IsNullOrEmpty(token);
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("token");
            await _localStorage.RemoveItemAsync("idUsuario");
            await _localStorage.RemoveItemAsync("nombre");
            await _localStorage.RemoveItemAsync("rol");
        }

        public async Task<UsuarioStorageDto> ObtenerStorage()
        {
            var token = await _localStorage.GetItemAsync<string>("token");

            if (string.IsNullOrEmpty(token))
            {
                return null;
            }

            return new UsuarioStorageDto
            {
                Id = await _localStorage.GetItemAsync<string>("idUsuario"),
                Token = token,
                Rol = await _localStorage.GetItemAsync<string>("rol"),
                NombreUsuario = await _localStorage.GetItemAsync<string>("nombre")
            };
        }
    }
}
