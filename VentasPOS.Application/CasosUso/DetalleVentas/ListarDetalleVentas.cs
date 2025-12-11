using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasPOS.Application.DTO.DetalleVentas;
using VentasPOS.Application.Interfaces.DetalleVentas;

namespace VentasPOS.Application.CasosUso.DetalleVentas
{
    public class ListarDetalleVentas: IListarDetalleVentas
    {
        private readonly IDetalleVentasRepository _repo;
        public ListarDetalleVentas(IDetalleVentasRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<DetalleVentasListarDto>> Handle(int ? IdVenta)
        {
            var response = await _repo.Listar(IdVenta);
            return response;
        }
    }
}
