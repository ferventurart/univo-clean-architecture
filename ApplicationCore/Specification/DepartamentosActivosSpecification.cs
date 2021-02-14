using ApplicationCore.Entities;
using Ardalis.Specification;

namespace ApplicationCore.Specification
{
    public sealed class DepartamentosActivosSpecification : Specification<Departamento>
    {
        public DepartamentosActivosSpecification()
        {
            Query.Where(c => c.Activo == true);
        }
    }
}
