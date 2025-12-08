using Microsoft.AspNetCore.Mvc;
using VentasPOS.Application.CasosUso.Ventas;

namespace VentasPOS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly ListarVentas _listarVentas;
        /*private readonly CrearVenta _crearVenta;
        private readonly ObtenerVenta _obtenerVenta;
        private readonly ActualizarVenta _actualizarVenta;*/

        public VentasController(ListarVentas listarVentas/*, crearVenta crearVenta, obtenerVenta obtenerVenta, actualizarVenta actualizarVenta*/)
        {
            _listarVentas = listarVentas;
            /*_crearVenta = crearVenta;
            _obtenerVenta = obtenerVenta;
            _actualizarVenta = actualizarVenta;*/
        }

        [HttpGet]
        public async Task <IActionResult> Listar()
        {
            var res = await _listarVentas.Handle();
            return Ok(res);
        }
    }
}
