using Microsoft.AspNetCore.Mvc;
using VentasPOS.Application.DTO.DetalleCompras;
using VentasPOS.Application.CasosUso.DetalleCompras;
using VentasPOS.Application.Interfaces.DetalleCompras;

namespace VentasPOS.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class DetalleComprasController : ControllerBase
    {
        private readonly IListarDetalleCompras _listarDetalleCompras;
        private readonly IInsertarDetalleCompras _insertarDetalleCompras;
        private readonly IActualizarDetalleCompra _actualizarDetalleCompra;
        private readonly EliminarDetalleCompras _eliminarDetalleCompra;

        public DetalleComprasController(IListarDetalleCompras listarDetalleCompras, IInsertarDetalleCompras insertarDetalleCompras, IActualizarDetalleCompra actualizarDetalleCompra, EliminarDetalleCompras eliminarDetalleCompra)
        {
            _listarDetalleCompras = listarDetalleCompras;
            _actualizarDetalleCompra = actualizarDetalleCompra;
            _insertarDetalleCompras = insertarDetalleCompras;
            _eliminarDetalleCompra = eliminarDetalleCompra;
        }

        [HttpGet]
        public async Task<IEnumerable<DetalleComprasListarDto>> Listar(int ?IdCompra)
        {
            var response = await _listarDetalleCompras.Handle(IdCompra);
            return response;
        }

        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] DetalleComprasInsertarDto detalleCompras)
        {
            var response = await _insertarDetalleCompras.Handle(detalleCompras);
            return Ok(response);
        }

        [HttpPatch("{Id}")]
        public async Task<IActionResult> Actualizr(int Id, [FromBody] DetalleComprasActualizarDto detalleCompras)
        {
            var response = await _actualizarDetalleCompra.Handle(Id, detalleCompras);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task <IActionResult> Eliminar(int Id)
        {
            var response = await _eliminarDetalleCompra.Handle(Id);
            return Ok(response);
        }

    }
}
