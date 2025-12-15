using System.Collections.ObjectModel;
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

        public async Task<ObservableCollection<VentaListarDto>> Listar()
        {
            try
            {
                var usuarios = await _http.GetFromJsonAsync<IEnumerable<VentaListarDto>>("Ventas");
                return new ObservableCollection<VentaListarDto>(usuarios ?? Enumerable.Empty<VentaListarDto>());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new ObservableCollection<VentaListarDto>();
            }
        }

        public async Task<bool> Insertar(VentaDetalleVentaInsertarDto request)
        {
            var response = await _http.PostAsJsonAsync("Ventas", request);
            return response.IsSuccessStatusCode;
        }

        public async Task<VentaListarDto> ObtenerPorId(int Id)
        {
            var response = await _http.GetFromJsonAsync<VentaListarDto>($"Ventas/Mostrar/{Id}");
            return response;
        }
    }
}
