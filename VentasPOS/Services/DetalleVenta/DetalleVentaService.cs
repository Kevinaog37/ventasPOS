using System.Net.Http.Json;
using VentasPOS.DTO.DetalleVenta;

namespace VentasPOS.Services.DetalleVenta
{
    public class DetalleVentaService
    {
        private readonly HttpClient _http;

        public DetalleVentaService(HttpClient http)
        {
            _http = http;
        }

        public async Task<IEnumerable<DetalleVentaListarDto>> ListarPorIdVenta(int IdVenta)
        {
            var res = await _http.GetFromJsonAsync<IEnumerable<DetalleVentaListarDto>>($"DetalleVentas/{IdVenta}");
            return res ?? Enumerable.Empty<DetalleVentaListarDto>();
        }

        public async Task<bool> Insertar(int IdVenta, DetalleVentaInsertarDto detalleVenta)
        {
            detalleVenta.IdVenta = IdVenta;
            var res = await _http.PostAsJsonAsync<DetalleVentaInsertarDto>("DetalleVentas", detalleVenta);
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> Actualizar(int Id, DetalleVentaActualizarDto detalleVenta)
        {
            var res = await _http.PutAsJsonAsync<DetalleVentaActualizarDto>($"DetalleVentas/{Id}", detalleVenta);
            return res.IsSuccessStatusCode;
        }

        public async Task<bool> Eliminar(int Id)
        {
            var res = await _http.DeleteFromJsonAsync<bool>($"DetalleVentas/{Id}");
            return res;
        }
    }
}
