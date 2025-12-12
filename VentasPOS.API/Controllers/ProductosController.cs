using Microsoft.AspNetCore.Mvc;
using VentasPOS.Application.DTO.Producto;
using VentasPOS.Application.Interfaces.Producto;

namespace VentasPOS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IListarProductos _listarProducto;

        public ProductosController(IListarProductos listarProducto)
        {
            _listarProducto = listarProducto;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductosListarDto>> Listar()
        {
            var response = await _listarProducto.Handle();
            return response;
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
