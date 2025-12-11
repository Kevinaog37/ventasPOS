using Microsoft.AspNetCore.Mvc;
using VentasPOS.Application.CasosUso.Usuarios;
using VentasPOS.Application.CasosUso.Ventas;
using VentasPOS.Application.DTO.Ventas;
using VentasPOS.Application.Interfaces.Ventas;

namespace VentasPOS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly IListarVentas _listarVentas;
        private readonly ICrearVenta _crearVenta;
        private readonly IObtenerVenta _obtenerVenta;
        private readonly IActualizarVenta _actualizarVenta;
        private readonly IEliminarVenta _eliminarVenta;

        public VentasController(IListarVentas listarVentas, ICrearVenta crearVenta, IObtenerVenta obtenerVenta, IActualizarVenta actualizarVenta, IEliminarVenta eliminarVenta)
        {
            _listarVentas = listarVentas;
            _crearVenta = crearVenta;
            _obtenerVenta = obtenerVenta;
            _actualizarVenta = actualizarVenta;
            _eliminarVenta = eliminarVenta;
        }

        [HttpGet]
        public async Task <IActionResult> Listar()
        {
            var res = await _listarVentas.Handle();
            return Ok(res);
        }

        [HttpGet("mostrar/{id}")]
        public async Task<IActionResult> Mostrar(int id)
        {
            var res = await _obtenerVenta.Handle(id);
            return Ok(res);
        }
        
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] VentaCrearDto venta)
        {
            var res = await _crearVenta.Handle(venta);
            return Ok(res);
        }

        [HttpPatch("actualizar/{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] VentaActualizarDto dto)
        {
            return Ok(await _actualizarVenta.Handle(id, dto));
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            return Ok(await _eliminarVenta.Handle(id));
        }
    }
}
