using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;

namespace Infraestructure.Repositories
{
    public class ProductoRepository : EfRepository<Producto, int>, IProductoRepository
    {
        public ProductoRepository(SysVentasDbContext dbContext) : base(dbContext) { }
    }
}
