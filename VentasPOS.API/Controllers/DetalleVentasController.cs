using Microsoft.AspNetCore.Mvc;
using VentasPOS.Application.CasosUso.DetalleVentas;
using VentasPOS.Application.DTO.DetalleVentas;
using VentasPOS.Application.Interfaces.DetalleVentas;

namespace VentasPOS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleVentasController : ControllerBase
    {
        private readonly IListarDetalleVentas _listarDetalleVentas;
        private readonly IInsertarDetalleVentas _insertarDetalleVentas;
        private readonly IActualizarDetalleVentas _actualizarDetalleVentas;
        private readonly EliminarDetalleVentas _eliminarDetalleVentas;

        public DetalleVentasController(IListarDetalleVentas listarDetalleVentas, IInsertarDetalleVentas insertarDetalleVentas, IActualizarDetalleVentas actualizarDetalleVentas, EliminarDetalleVentas eliminarDetalleVentas)
        {
            _listarDetalleVentas = listarDetalleVentas;
            _insertarDetalleVentas = insertarDetalleVentas;
            _actualizarDetalleVentas = actualizarDetalleVentas;
            _eliminarDetalleVentas = eliminarDetalleVentas;
        }

        [HttpGet("{IdVenta}")]
        public async Task<IEnumerable<DetalleVentasListarDto>> Listar(int? IdVenta)
        {
            var result = await _listarDetalleVentas.Handle(IdVenta);
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DetalleVentaInsertarDto detalleVenta)
        {
            return Ok(await _insertarDetalleVentas.Handle(detalleVenta));
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, [FromBody] DetalleVentaActualizarDto detalleVenta)
        {
            var response = await _actualizarDetalleVentas.Handle(Id, detalleVenta);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _eliminarDetalleVentas.Handle(id);
            return Ok(response);
        }
    }
}
