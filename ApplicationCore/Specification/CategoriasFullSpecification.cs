using ApplicationCore.Entities;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Specification
{
    public sealed class CategoriasFullSpecification : Specification<Categoria>
    {
        public CategoriasFullSpecification()
        {
            Query.Include(c => c.Departamento);
        }
    }
}
