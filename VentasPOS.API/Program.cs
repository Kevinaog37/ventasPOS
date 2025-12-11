using ComprasPOS.Infraestructure.Repositories;
using Microsoft.Data.SqlClient;
using System.Data;
using VentasPOS.Application.CasosUso.Compras;
using VentasPOS.Application.CasosUso.DetalleVentas;
using VentasPOS.Application.CasosUso.Usuarios;
using VentasPOS.Application.CasosUso.Ventas;
using VentasPOS.Application.Interfaces.Compras;
using VentasPOS.Application.Interfaces.DetalleVentas;
using VentasPOS.Application.Interfaces.Usuarios;
using VentasPOS.Application.Interfaces.Ventas;
using VentasPOS.Infraestructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("https://localhost:7035")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// DB
builder.Services.AddScoped<IDbConnection>(db =>
    new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

// ===== Usuarios =====
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ICrearUsuario, CrearUsuario>();
builder.Services.AddScoped<IActualizarUsuario, ActualizarUsuario>();
builder.Services.AddScoped<IObtenerUsuario, ObtenerUsuario>();
builder.Services.AddScoped<IListarUsuario, ListarUsuario>();
builder.Services.AddScoped<IEliminarUsuario, EliminarUsuario>();

// ===== Ventas =====
builder.Services.AddScoped<IVentaRepository, VentaRepository>();
builder.Services.AddScoped<ICrearVenta, CrearVenta>();
builder.Services.AddScoped<IActualizarVenta, ActualizarVenta>();
builder.Services.AddScoped<IObtenerVenta, ObtenerVenta>();
builder.Services.AddScoped<IListarVentas, ListarVentas>();
builder.Services.AddScoped<IEliminarVenta, EliminarVenta>();

// ===== Compras =====
builder.Services.AddScoped<ICompraRepository, CompraRepository>();
builder.Services.AddScoped<ICrearCompra, CrearCompra>();
builder.Services.AddScoped<IActualizarCompra, ActualizarCompra>();
builder.Services.AddScoped<IObtenerCompra, ObtenerCompra>();
builder.Services.AddScoped<IListarCompras, ListarCompras>();
builder.Services.AddScoped<IEliminarCompra, EliminarCompra>();

// ===== DetalleVentas =====
builder.Services.AddScoped<IDetalleVentasRepository, DetalleVentaRepository>();
builder.Services.AddScoped<IInsertarDetalleVentas, InsertarDetalleVentas>();
builder.Services.AddScoped<IListarDetalleVentas, ListarDetalleVentas>();
builder.Services.AddScoped<IActualizarDetalleVentas, ActualizarDetalleVentas>();
builder.Services.AddScoped<EliminarDetalleVentas>();

var app = builder.Build();

// Pipeline
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
