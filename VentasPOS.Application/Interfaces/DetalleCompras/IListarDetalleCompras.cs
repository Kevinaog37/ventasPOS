using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasPOS.Application.DTO.DetalleCompras;

namespace VentasPOS.Application.Interfaces.DetalleCompras
{
    public interface IListarDetalleCompras
    {
        Task<IEnumerable<DetalleComprasListarDto>> Handle(int ?IdCompra);
    }
}
