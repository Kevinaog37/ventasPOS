using System.Collections.ObjectModel;
using VentasPOS.DTO.Compra;
using VentasPOS.Services.Compra;

namespace VentasPOS.ViewModels.Venta
{
    public class CompraListarViewModel
    {
        private readonly CompraService _compraService;
        public ObservableCollection<CompraListarDto> _listVentas = new();

        public CompraListarViewModel(CompraService compraService)
        {
            _compraService = compraService;
        }

        public async Task Listar()
        {
            _listVentas = await _compraService.Listar();
        }
    }
}
