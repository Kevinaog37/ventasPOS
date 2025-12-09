using ComprasPOS.Infraestructure.Repositories;
using Microsoft.Data.SqlClient;
using System.Data;
using VentasPOS.Application.CasosUso.Compras;
using VentasPOS.Application.CasosUso.Usuarios;
using VentasPOS.Application.CasosUso.Ventas;
using VentasPOS.Application.Interfaces.Compras;
using VentasPOS.Application.Interfaces.Usuarios;
using VentasPOS.Application.Interfaces.Ventas;
using VentasPOS.Infraestructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("https://localhost:7035") 
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Conexión DB
builder.Services.AddScoped<IDbConnection>(db =>
    new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

// [Casos de uso]
//Usuarios
builder.Services.AddScoped<CrearUsuario>();
builder.Services.AddScoped<ObtenerUsuario>();
builder.Services.AddScoped<ListarUsuario>();
builder.Services.AddScoped<ActualizarUsuario>();
builder.Services.AddScoped<EliminarUsuario>();

//Ventas
builder.Services.AddScoped<ListarVentas>();
builder.Services.AddScoped<CrearVenta>();
builder.Services.AddScoped<ActualizarVenta>();
builder.Services.AddScoped<EliminarVenta>();
builder.Services.AddScoped<ObtenerVenta>();

//Compras
builder.Services.AddScoped<ListarCompras>();
builder.Services.AddScoped<CrearCompra>();
builder.Services.AddScoped<ActualizarCompra>();
builder.Services.AddScoped<EliminarCompra>();
builder.Services.AddScoped<ObtenerCompra>();


// [Dependencias]
//Usuarios
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IActualizarUsuario, ActualizarUsuario>();
builder.Services.AddScoped<ICrearUsuario, CrearUsuario>();
builder.Services.AddScoped<IObtenerUsuario, ObtenerUsuario>();

//Ventas
builder.Services.AddScoped<IVentaRepository, VentaRepository>();
builder.Services.AddScoped<IListarVentas, ListarVentas>();
builder.Services.AddScoped<ICrearVenta, CrearVenta>();
builder.Services.AddScoped<IActualizarVenta, ActualizarVenta>();
builder.Services.AddScoped<IObtenerVenta, ObtenerVenta>();

//Compras
builder.Services.AddScoped<ICompraRepository, CompraRepository>();
builder.Services.AddScoped<IListarCompras, ListarCompras>();
builder.Services.AddScoped<ICrearCompra, CrearCompra>();
builder.Services.AddScoped<IActualizarCompra, ActualizarCompra>();
builder.Services.AddScoped<IObtenerCompra, ObtenerCompra>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowLocalhost");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
