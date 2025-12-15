using System.Collections.ObjectModel;
using VentasPOS.DTO.Compra;
using VentasPOS.DTO.DetalleCompra;
using VentasPOS.DTO.Producto;
using VentasPOS.DTO.Usuario;
using VentasPOS.Services.Compra;
using VentasPOS.Services.Producto;
using VentasPOS.Services.Usuario;

public class CompraCrearViewModel
{
    private readonly CompraService _compraService;
    private readonly UsuarioService _usuarioService;
    private readonly ProductoService _productoService;

    public ObservableCollection<UsuarioListarDto> ListaVendedor = new();
    public ObservableCollection<UsuarioListarDto> ListaProveedor = new();
    public ObservableCollection<ProductoListarDto> ListaProducto = new();
    public ObservableCollection<DetalleCompraInsertarDto> ListaDetalleCompra = new();

    public CompraCrearDto Compra = new();
    public DetalleCompraInsertarDto DetalleCompra = new();

    public bool CompraCreada = false;

    public CompraCrearViewModel(CompraService compreService, UsuarioService usuarioService, ProductoService productoService)
    {
        _compraService = compreService;
        _usuarioService = usuarioService;
        _productoService = productoService;
    }

    public async Task CargarUsuarios()
    {
        ListaVendedor = await _usuarioService.Listar();
        ListaProveedor = await _usuarioService.Listar();
        ListaProducto = await _productoService.Listar();
    }

    public void AgregarDetalle()
    {
        ListaDetalleCompra.Add(new DetalleCompraInsertarDto
        {
            IdProducto = DetalleCompra.IdProducto,
            Precio = DetalleCompra.Precio,
            Cantidad = DetalleCompra.Cantidad,
            Fecha = DetalleCompra.Fecha,
            Estado = DetalleCompra.Estado,
        });
    }

    public void EliminarDetalleCompra(DetalleCompraInsertarDto detalleCompra)
    {
        ListaDetalleCompra.Remove(detalleCompra);
    }

    public async Task FinalizarCompra()
    {
        CompraDetalleCompraInsertarDto CompraInsertar = new CompraDetalleCompraInsertarDto
        {
            IdUsuarioVendedor = Compra.IdUsuarioVendedor,
            IdUsuarioProveedor = Compra.IdUsuarioProveedor,
            Fecha = Compra.Fecha,
            Estado = Compra.Estado,
            DetalleCompra = ListaDetalleCompra
        };

        Console.WriteLine("CompraCrearViewModel| Detalles de compra: " + CompraInsertar.DetalleCompra.Count);

        if (await _compraService.Insertar(CompraInsertar))
        {
            CompraCreada = true;
        }
    }

    public void LimpiarDatos()
    {
        Compra = new();
        DetalleCompra = new();
        ListaDetalleCompra.Clear();
        CompraCreada = false;
    }
}
