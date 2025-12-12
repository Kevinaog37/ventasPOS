using System.Collections;
using System.Collections.ObjectModel;
using System.Net.Http.Json;
using VentasPOS.DTO.Producto;

namespace VentasPOS.Services.Producto
{
    public class ProductoService
    {
        private readonly HttpClient _httpClient;

        public ProductoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient = httpClient;
        }

        public async Task<ObservableCollection<ProductoListarDto>> Listar()
        {
            var response = await _httpClient.GetFromJsonAsync<IEnumerable<ProductoListarDto>>("Productos");
            return new ObservableCollection<ProductoListarDto>(response ?? Enumerable.Empty<ProductoListarDto>());
        }
    }
}
