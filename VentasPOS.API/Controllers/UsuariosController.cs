using Microsoft.AspNetCore.Mvc;
using VentasPOS.Application.DTO;
using VentasPOS.Application.Interfaces;

namespace VentasPOS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuariosController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var res = await _service.Listar();
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Obtener(int id)
        {
            var data = await _service.ObtenerPorId(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] UsuarioCrearDto dto)
        {
            var id = await _service.Crear(dto);
            return Ok(new { Id = id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] UsuarioCrearDto dto)
            => Ok(await _service.Actualizar(id, dto));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
            => Ok(await _service.Eliminar(id));
    }
}
