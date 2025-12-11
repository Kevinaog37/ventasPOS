namespace VentasPOS.Application.Interfaces.Compras
{
    public interface IEliminarCompra
    {
        public Task<bool> Handle(int id);
    }
}
