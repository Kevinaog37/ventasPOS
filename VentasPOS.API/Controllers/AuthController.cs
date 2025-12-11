using Microsoft.AspNetCore.Mvc;
using VentasPOS.Application.CasosUso.Auth;
using VentasPOS.Application.DTO.Auth;

namespace VentasPOS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly Login _login;
        public AuthController(Login login)
        {
            _login = login;
        }
        
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var usuario = await _login.Handle(request);

            if (usuario == null || usuario.Id == 0)
                return Unauthorized(new { message = "Credenciales incorrectas" });

            return Ok(usuario);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
