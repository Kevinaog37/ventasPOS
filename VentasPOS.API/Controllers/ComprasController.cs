using Microsoft.AspNetCore.Mvc;
using VentasPOS.Application.CasosUso.Usuarios;
using VentasPOS.Application.CasosUso.Compras;
using VentasPOS.Application.DTO.Compras;

namespace ComprasPOS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        private readonly ListarCompras _listarCompras;
        private readonly CrearCompra _crearCompra;
        private readonly ObtenerCompra _obtenerCompra;
        private readonly ActualizarCompra _actualizarCompra;
        private readonly EliminarCompra _eliminarCompra;

        public ComprasController(ListarCompras listarCompras, CrearCompra crearCompra, ObtenerCompra obtenerCompra, ActualizarCompra actualizarCompra, EliminarCompra eliminarCompra)
        {
            _listarCompras = listarCompras;
            _crearCompra = crearCompra;
            _obtenerCompra = obtenerCompra;
            _actualizarCompra = actualizarCompra;
            _eliminarCompra = eliminarCompra;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            Console.WriteLine("CompraController");
            var res = await _listarCompras.Handle();
            return Ok(res);
        }

        [HttpGet("mostrar/{id}")]
        public async Task<IActionResult> Mostrar(int id)
        {
            var res = await _obtenerCompra.Handle(id);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CompraCrearDto venta)
        {
            var res = await _crearCompra.Handle(venta);
            return Ok(res);
        }

        [HttpPatch("actualizar/{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] CompraActualizarDto dto)
        {
            return Ok(await _actualizarCompra.Handle(id, dto));
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            return Ok(await _eliminarCompra.Handle(id));
        }
    }
}
