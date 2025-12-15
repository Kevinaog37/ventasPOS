using System.Collections.ObjectModel;
using System.Net.Http.Json;
using VentasPOS.DTO.Compra;

namespace VentasPOS.Services.Compra
{
    public class CompraService
    {
        private readonly HttpClient _http;

        public CompraService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ObservableCollection<CompraListarDto>> Listar()
        {
            try
            {
                var compras = await _http.GetFromJsonAsync<IEnumerable<CompraListarDto>>("Compras");
                return new ObservableCollection<CompraListarDto>(compras ?? Enumerable.Empty<CompraListarDto>());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new ObservableCollection<CompraListarDto>();
            }
        }

        public async Task<bool> Insertar(CompraDetalleCompraInsertarDto request)
        {
            var response = await _http.PostAsJsonAsync("Compras", request);
            return response.IsSuccessStatusCode;
        }
    }
}
