using VentasPOS.Application.DTO.Ventas;
using VentasPOS.Domain.Entities;
namespace VentasPOS.Application.Interfaces.Ventas
{
    public interface IVentaRepository
    {
        Task<IEnumerable<VentaListarDto>> Listar();
    }

}

