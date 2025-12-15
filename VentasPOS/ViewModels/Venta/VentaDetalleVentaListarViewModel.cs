using System.Collections.ObjectModel;
using VentasPOS.DTO.DetalleVenta;
using VentasPOS.DTO.Producto;
using VentasPOS.DTO.Usuario;
using VentasPOS.DTO.Venta;
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

        public ObservableCollection<UsuarioListarDto> ListaCliente = new();
        public ObservableCollection<UsuarioListarDto> ListaProveedor = new();
        public ObservableCollection<ProductoListarDto> ListaProducto = new();
        public ObservableCollection<DetalleVentaInsertarDto> ListaDetalleVenta = new();

        public VentaCrearDto Venta = new();
        public DetalleVentaInsertarDto DetalleVenta = new();

        public bool VentaEncontrada = false;

        public VentaDetalleVentaListarViewModel(VentaService ventaService, UsuarioService usuarioService, ProductoService productoService)
        {
            _ventaService = ventaService;
            _usuarioService = usuarioService;
            _ProductoService = productoService;
        }

        public async Task CargarUsuarios()
        {
            ListaCliente = await _usuarioService.Listar();
            ListaProveedor = await _usuarioService.Listar();
            ListaProducto = await _ProductoService.Listar();
        }
        public async Task CargarVenta(int Id = -1)
        {
            var res = await _ventaService.ObtenerPorId(Id);
            if (res.IdUsuarioProveedor > 0)
            {
                Console.WriteLine("VentaDetalleVentaListarVM | " + res.IdUsuarioProveedor);  
                Venta = new VentaCrearDto { IdUsuarioCliente = res.IdUsuarioCliente, IdUsuarioProveedor = res.IdUsuarioProveedor, Fecha = res.Fecha, Estado = res.Estado };
            }
        }
        public void AgregarDetalle()
        {
            ListaDetalleVenta.Add(new DetalleVentaInsertarDto
            {
                IdProducto = DetalleVenta.IdProducto,
                Cantidad = DetalleVenta.Cantidad,
                Estado = DetalleVenta.Estado,
                NombreProducto = DetalleVenta.NombreProducto,
                Precio = DetalleVenta.Precio
            });
        }

        public void EliminarDetalleVenta(DetalleVentaInsertarDto detalleVenta)
        {
            ListaDetalleVenta.Remove(detalleVenta);
        }

        public async Task FinalizarVenta()
        {
            VentaDetalleVentaInsertarDto VentaInsertar = new VentaDetalleVentaInsertarDto
            {
                IdUsuarioCliente = Venta.IdUsuarioCliente,
                IdUsuarioProveedor = Venta.IdUsuarioProveedor,
                Estado = Venta.Estado,
                Fecha = Venta.Fecha,
                DetalleVenta = ListaDetalleVenta
            };
            if (await _ventaService.Insertar(VentaInsertar))
            {
                VentaEncontrada = true;
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
