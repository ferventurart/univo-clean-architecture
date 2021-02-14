using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;

namespace Infraestructure.Repositories
{
    public class CategoriaRepository : EfRepository<Categoria, int>, ICategoriaRepository
    {
        public CategoriaRepository(SysVentasDbContext dbContext) : base(dbContext) { }
    }
}
