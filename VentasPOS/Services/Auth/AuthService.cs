using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using VentasPOS.DTO.Auth;

namespace VentasPOS.Services.Auth
{
    public class AuthService
    {
        private readonly HttpClient _http;

        public AuthService(HttpClient http)
        {
            _http = http;
        }

        public async Task<bool> Login(LoginRequest request)
        {
            var response = await _http.PostAsJsonAsync("auth/login", request);

            //return response.IsSuccessStatusCode;
            return true;
        }
    }
}
