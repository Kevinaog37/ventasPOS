using VentasPOS.Domain.Entities;
using VentasPOS.DTO.Usuario;
using VentasPOS.DTO.Venta;
using VentasPOS.Services.Usuario;
using VentasPOS.Services.Venta;

public class VentaCrearViewModel
{
    private readonly VentaService _ventaService;
    private readonly UsuarioService _usuarioService;

    public List<UsuarioListarDto> ListaCliente = new();
    public List<UsuarioListarDto> ListaProveedor = new();
    public List<VentaListarDto> ListVentas = new();
    public VentaCrearDto Venta { get; set; } = new();

    public int ClienteSeleccionado { get; set; }
    public int ProveedorSeleccionado { get; set; }

    public VentaCrearViewModel(VentaService ventaService, UsuarioService usuarioService)
    {
        _ventaService = ventaService;
        _usuarioService = usuarioService;
    }

    public async Task cargarUsuarios()
    {
        ListaCliente = await _usuarioService.Listar();
        ListaProveedor = await _usuarioService.Listar();
    }

    public async Task Listar()
    {
        ListVentas = await _ventaService.Listar();
    }

    public async Task Guardar()
    {
        Console.WriteLine(Venta.ToString());
        var res = await _ventaService.Insertar(Venta);

        if (res)
        {
        }
        else
        {
        }
    }
}
