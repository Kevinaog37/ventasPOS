using System.Net.Http.Json;
using VentasPOS.DTO.Venta;

namespace VentasPOS.Services.Venta
{
    public class VentaService
    {
        private readonly HttpClient _http;

        public VentaService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<VentaListarDto>> Listar()
        {
            try
            {
                var usuarios = await _http.GetFromJsonAsync<IEnumerable<VentaListarDto>>("Ventas");
                return usuarios?.ToList() ?? new List<VentaListarDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<VentaListarDto>();
            }
        }

        public async Task<bool> Insertar(VentaCrearDto request)
        {
            var response = await _http.PostAsJsonAsync("Ventas", request);
            return response.IsSuccessStatusCode;
        }
    }
}
