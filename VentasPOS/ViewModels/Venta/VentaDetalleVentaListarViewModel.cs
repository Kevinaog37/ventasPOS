using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VentasPOS.DTO.DetalleVenta;
using VentasPOS.DTO.Producto;
using VentasPOS.DTO.Usuario;
using VentasPOS.DTO.Venta;
using VentasPOS.Services.DetalleVenta;
using VentasPOS.Services.Producto;
using VentasPOS.Services.Usuario;
using VentasPOS.Services.Venta;

namespace VentasPOS.ViewModels.Venta
{
    public class VentaDetalleVentaListarViewModel
    {
        private readonly VentaService _ventaService;
        private readonly UsuarioService _usuarioService;
        private readonly ProductoService _ProductoService;
        private readonly DetalleVentaService _detalleVentaService;


        public ObservableCollection<UsuarioListarDto> ListaCliente = new();
        public ObservableCollection<UsuarioListarDto> ListaProveedor = new();
        public ObservableCollection<ProductoListarDto> ListaProducto = new();
        public ObservableCollection<DetalleVentaListarDto> ListaDetalleVenta = new();

        public VentaCrearDto Venta = new();
        public DetalleVentaInsertarDto DetalleVenta = new();

        public bool VentaEncontrada = false;

        public VentaDetalleVentaListarViewModel(VentaService ventaService, UsuarioService usuarioService, ProductoService productoService, DetalleVentaService detalleVentaService)
        {
            _ventaService = ventaService;
            _usuarioService = usuarioService;
            _ProductoService = productoService;
            _detalleVentaService = detalleVentaService;
        }

        public async Task CargarUsuarios()
        {
            ListaCliente = await _usuarioService.Listar();
            ListaProveedor = await _usuarioService.Listar();
            ListaProducto = await _ProductoService.Listar();
        }

        public async Task CargarVenta(int Id)
        {
            var res = await _ventaService.ObtenerPorId(Id);
            if (res.IdUsuarioProveedor > 0)
            {
                Venta.IdUsuarioCliente = res.IdUsuarioCliente;
                Venta.IdUsuarioProveedor = res.IdUsuarioProveedor;
                Venta.Fecha = res.Fecha;
                Venta.Estado = res.Estado;

                var res2 = await _detalleVentaService.ListarPorIdVenta(Id);
                foreach (var det in res2)
                {
                    ListaDetalleVenta.Add(new DetalleVentaListarDto { Id = det.Id, Cantidad = det.Cantidad, Estado = det.Estado, IdProducto = det.IdProducto, IdVenta = det.IdVenta, Precio = det.Precio });
                }

            }
        }

        public async Task AgregarDetalle(int? IdVenta)
        {
            var res = await _detalleVentaService.Insertar(IdVenta ?? 0, DetalleVenta);
            if (res)
            {
                ListaDetalleVenta.Add(new DetalleVentaListarDto
                {
                    IdVenta = DetalleVenta.IdVenta,
                    IdProducto = DetalleVenta.IdProducto,
                    Cantidad = DetalleVenta.Cantidad,
                    Estado = DetalleVenta.Estado,
                    Precio = DetalleVenta.Precio
                });
            }

        }
        public async Task ActualizarDetalleVenta(DetalleVentaListarDto detalleVenta)
        {
            DetalleVentaActualizarDto detalleActualizar = new DetalleVentaActualizarDto { Precio = detalleVenta.Precio, Cantidad = detalleVenta.Cantidad, Estado = detalleVenta.Estado, IdProducto = detalleVenta.IdProducto };
            var response = await _detalleVentaService.Actualizar(detalleVenta.Id, detalleActualizar);
        }
        public async Task EliminarDetalleVenta(DetalleVentaListarDto detalleVenta)
        {
            var res = await _detalleVentaService.Eliminar(detalleVenta.Id);

            if (res)
            {
                ListaDetalleVenta.Remove(detalleVenta);
            }
        }

        public async Task LimpiarDatos()
        {
            Venta = new();
            DetalleVenta = new();
            ListaDetalleVenta.Clear();
            VentaEncontrada = false;
            await Task.CompletedTask;
        }
    }
}
