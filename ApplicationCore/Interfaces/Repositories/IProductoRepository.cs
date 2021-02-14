using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces.Repositories
{
    public interface IProductoRepository : IAsyncRepository<Producto, int>
    {
    }
}
