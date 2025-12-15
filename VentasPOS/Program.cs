using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using VentasPOS;
using VentasPOS.Services.Auth;
using VentasPOS.Services.Compra;
using VentasPOS.Services.DetalleVenta;
using VentasPOS.Services.Producto;
using VentasPOS.Services.Usuario;
using VentasPOS.Services.Venta;
using VentasPOS.ViewModels.Auth;
using VentasPOS.ViewModels.Usuario;
using VentasPOS.ViewModels.Venta;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7295/api/") });
//[ViewModels]
//Auth
builder.Services.AddScoped<AuthViewModel>();
//Usuario
builder.Services.AddScoped<UsuarioListarViewModel>();
builder.Services.AddScoped<UsuarioCrearViewModel>();
builder.Services.AddScoped<UsuarioEditarViewModel>();
//Ventas 
builder.Services.AddScoped<VentaListarViewModel>();
builder.Services.AddScoped<VentaCrearViewModel>();
builder.Services.AddScoped<VentaDetalleVentaListarViewModel>();


//Ventas 
builder.Services.AddScoped<CompraListarViewModel>();
builder.Services.AddScoped<CompraCrearViewModel>();

//[Services]
//Auth
builder.Services.AddScoped<AuthService>();
builder.Services.AddBlazoredLocalStorage();

//Usuario
builder.Services.AddScoped<UsuarioService>();
//Ventas
builder.Services.AddScoped<VentaService>();
//Compras
builder.Services.AddScoped<CompraService>();
//Productos
builder.Services.AddScoped<ProductoService>();
//DetalleVentas
builder.Services.AddScoped<DetalleVentaService>();





await builder.Build().RunAsync();
