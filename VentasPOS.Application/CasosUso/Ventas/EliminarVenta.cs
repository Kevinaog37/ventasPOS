using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasPOS.Application.Interfaces.Usuarios;
using VentasPOS.Application.Interfaces.Ventas;

namespace VentasPOS.Application.CasosUso.Ventas
{
    public class EliminarVenta
    {   
        private readonly IVentaRepository _repo; 

        public EliminarVenta(IVentaRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(int id)
        {
            return await _repo.Eliminar(id);
        }
    }
}
