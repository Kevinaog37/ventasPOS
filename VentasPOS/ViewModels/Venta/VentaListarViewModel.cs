using VentasPOS.DTO.Venta;
using VentasPOS.Services.Venta;

namespace VentasPOS.ViewModels.Venta
{
    public class VentaListarViewModel
    {
        private readonly VentaService _ventaService;
        public List<VentaListarDto> _listVentas = new();

        public VentaListarViewModel(VentaService ventaService)
        {
            _ventaService = ventaService;
        }

        public async Task Listar()
        {
            _listVentas = await _ventaService.Listar();
        }
    }
}
