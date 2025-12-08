using System.Data;
using Microsoft.Data.SqlClient;
using VentasPOS.Application.CasosUso.Usuarios;
using VentasPOS.Application.Interfaces.Usuarios;
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

// Casos de uso
builder.Services.AddScoped<CrearUsuario>();
builder.Services.AddScoped<ObtenerUsuario>();
builder.Services.AddScoped<ListarUsuario>();
builder.Services.AddScoped<ActualizarUsuario>();
builder.Services.AddScoped<EliminarUsuario>();

// Dependencias
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IActualizarUsuario, ActualizarUsuario>();
builder.Services.AddScoped<ICrearUsuario, CrearUsuario>();
builder.Services.AddScoped<IObtenerUsuario, ObtenerUsuario>();


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
