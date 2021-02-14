using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Repositories;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class EfRepository<TEntity, TKey> : IAsyncRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>, IAggregateRoot
    {
        protected readonly SysVentasDbContext _dbContext;

        public EfRepository(SysVentasDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity;
        }

        public async Task<int> CountAsync(ISpecification<TEntity> spec, CancellationToken cancellationToken = default)
        {
            var specificationResult = ApplySpecification(spec);
            return await specificationResult.CountAsync(cancellationToken);
        }

        public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<TEntity> FirstAsync(ISpecification<TEntity> spec, CancellationToken cancellationToken = default)
        {
            var specificationResult = ApplySpecification(spec);
            return await specificationResult.FirstAsync(cancellationToken);
        }

        public async Task<TEntity> FirstOrDefaultAsync(ISpecification<TEntity> spec, CancellationToken cancellationToken = default)
        {
            var specificationResult = ApplySpecification(spec);
            return await specificationResult.FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var keyValues = new object[] { id };
            return await _dbContext.Set<TEntity>().FindAsync(keyValues, cancellationToken);
        }

        public async Task<IReadOnlyList<TEntity>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<TEntity>().ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<TEntity>> ListAsync(ISpecification<TEntity> spec, CancellationToken cancellationToken = default)
        {
            var specificationResult = ApplySpecification(spec);
            return await specificationResult.ToListAsync(cancellationToken);
        }

        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> spec)
        {
            var evaluator = new SpecificationEvaluator<TEntity>();
            return evaluator.GetQuery(_dbContext.Set<TEntity>().AsQueryable(), spec);
        }
    }
}
