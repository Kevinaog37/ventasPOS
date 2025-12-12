using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasPOS.Application.DTO.Producto;

namespace VentasPOS.Application.Interfaces.Producto
{
    public interface IProductoRepository
    {
        public Task<IEnumerable<ProductosListarDto>> Listar();
    }
}
