using ApplicationCore.Interfaces;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public class Categoria : BaseEntity<int>, IAggregateRoot
    {
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        public List<Producto> Productos { get; set; }
    }
}
