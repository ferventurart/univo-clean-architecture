using System;

namespace ApplicationCore.Entities
{
    public abstract class BaseEntity<T>
    {
        public virtual T Id { get; protected set; }
        public virtual DateTime CreatedDT { get; set; }
        public virtual DateTime? ModifiedDT { get; set; }
    }
}
