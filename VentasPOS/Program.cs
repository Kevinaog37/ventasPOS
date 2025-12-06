using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using VentasPOS;
using VentasPOS.Services.Auth;
using VentasPOS.Services.Usuario;
using VentasPOS.ViewModels.Auth;
using VentasPOS.ViewModels.Usuario;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//[ViewModels]
//Auth
builder.Services.AddScoped<AuthViewModel>();
//Usuario
builder.Services.AddScoped<UsuarioViewModel>();
builder.Services.AddScoped<UsuarioCrearViewModel>();
builder.Services.AddScoped<UsuarioMostrarViewModel>();


//Services
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<UserSessionService>();
builder.Services.AddScoped<UsuarioService>();


await builder.Build().RunAsync();
