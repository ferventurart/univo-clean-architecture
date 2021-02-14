using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Repositories;

namespace Infraestructure.Repositories
{
    public class DepartamentoRepository : EfRepository<Departamento, int>, IDepartamentoRepository
    {
        public DepartamentoRepository(SysVentasDbContext dbContext): base(dbContext){}
    }
}
