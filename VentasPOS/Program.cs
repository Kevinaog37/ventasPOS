using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using VentasPOS;
using VentasPOS.Services.Auth;
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

//[Services]
//Auth
builder.Services.AddScoped<AuthService>();
//Usuario
builder.Services.AddScoped<UserSessionService>();
builder.Services.AddScoped<UsuarioService>();
//Vebtas
builder.Services.AddScoped<VentaService>();


await builder.Build().RunAsync();
