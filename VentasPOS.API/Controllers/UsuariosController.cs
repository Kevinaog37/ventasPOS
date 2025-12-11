using Microsoft.AspNetCore.Mvc;
using VentasPOS.Application.CasosUso.Usuarios;
using VentasPOS.Application.DTO.Usuarios;
using VentasPOS.Application.Interfaces.Usuarios;

namespace VentasPOS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ICrearUsuario _crearUsuario;
        private readonly IObtenerUsuario _obtenerUsuario;
        private readonly IListarUsuario _listarUsuarios;
        private readonly IActualizarUsuario _actualizarUsuario;
        private readonly IEliminarUsuario _eliminarUsuario;

        public UsuariosController(
            ICrearUsuario crearUsuario,
            IObtenerUsuario obtenerUsuario,
            IListarUsuario listarUsuarios,
            IActualizarUsuario actualizarUsuario,
            IEliminarUsuario eliminarUsuario)
        {
            _crearUsuario = crearUsuario;
            _obtenerUsuario = obtenerUsuario;
            _listarUsuarios = listarUsuarios;
            _actualizarUsuario = actualizarUsuario;
            _eliminarUsuario = eliminarUsuario;
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var res = await _listarUsuarios.Handle();
            return Ok(res);
        }

        [HttpGet("mostrar/{id}")]
        public async Task<IActionResult> Obtener(int id)
        {
            var data = await _obtenerUsuario.Handle(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] UsuarioCrearDto dto)
        {
            var id = await _crearUsuario.Handle(dto);
            return Ok(new { Id = id });
        }

        [HttpPatch("actualizar/{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] UsuarioActualizarDto dto)
        {
            return Ok(await _actualizarUsuario.Handle(id, dto));
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            return Ok(await _eliminarUsuario.Handle(id));
        }
    }
}
