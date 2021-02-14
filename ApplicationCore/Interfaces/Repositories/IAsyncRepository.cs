using ApplicationCore.Entities;
using Ardalis.Specification;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Repositories
{
    public interface IAsyncRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>, IAggregateRoot
    {
        Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<TEntity>> ListAllAsync(CancellationToken cancellationToken = default);
        Task<IReadOnlyList<TEntity>> ListAsync(ISpecification<TEntity> spec, CancellationToken cancellationToken = default);
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<int> CountAsync(ISpecification<TEntity> spec, CancellationToken cancellationToken = default);
        Task<TEntity> FirstAsync(ISpecification<TEntity> spec, CancellationToken cancellationToken = default);
        Task<TEntity> FirstOrDefaultAsync(ISpecification<TEntity> spec, CancellationToken cancellationToken = default);
    }
}
