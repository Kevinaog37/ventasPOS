using Microsoft.AspNetCore.Mvc;
using VentasPOS.Application.CasosUso.Usuarios;
using VentasPOS.Application.DTO.Usuarios;

namespace VentasPOS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly CrearUsuario _crearUsuario;
        private readonly ObtenerUsuario _obtenerUsuario;
        private readonly ListarUsuario _listarUsuarios;
        private readonly ActualizarUsuario _actualizarUsuario;
        private readonly EliminarUsuario _eliminarUsuario;

        public UsuariosController(
            CrearUsuario crearUsuario,
            ObtenerUsuario obtenerUsuario,
            ListarUsuario listarUsuarios,
            ActualizarUsuario actualizarUsuario,
            EliminarUsuario eliminarUsuario)
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
