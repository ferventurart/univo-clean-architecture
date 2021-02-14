using ApplicationCore.Interfaces;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public class Departamento : BaseEntity<int>, IAggregateRoot
    {
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        public List<Categoria> Categorias { get; set; }
    }
}
