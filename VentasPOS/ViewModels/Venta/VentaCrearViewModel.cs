using System.Collections.ObjectModel;
using VentasPOS.DTO.Venta;
using VentasPOS.DTO.Usuario;
using VentasPOS.Services.Usuario;
using VentasPOS.Services.Venta;
using VentasPOS.DTO.DetalleVenta;
using VentasPOS.DTO.Producto;
using VentasPOS.Services.Producto;

public class VentaCrearViewModel
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

    public bool VentaCreada = false;

    public VentaCrearViewModel(VentaService ventaService, UsuarioService usuarioService, ProductoService productoService)
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

    public void AgregarDetalle()
    {
        ListaDetalleVenta.Add(new DetalleVentaInsertarDto
        {
            IdProducto = DetalleVenta.IdProducto,
            Cantidad = DetalleVenta.Cantidad,
            Estado = DetalleVenta.Estado,
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
            VentaCreada = true;
        }
    }

    public void LimpiarDatos()
    {
        Venta = new();
        DetalleVenta = new();
        ListaDetalleVenta.Clear();
        VentaCreada = false;
    }
}
