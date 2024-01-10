using Microsoft.EntityFrameworkCore;
using Social.Sport.Core.Entities;
using Social.Sport.Core.Interfaces.Data;

namespace Social.Sport.Infrastructure.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private DbSet<TEntity> _dbSet;

        public Repository(AppDbContext dbContext)
        {
            _dbSet = dbContext.Set<TEntity>();
        }

        public void AddAsync(TEntity entity, CancellationToken cancellation)
        {
            _dbSet.AddAsync(entity, cancellation);
        }

        public IQueryable<TEntity> Get()
        {
            return _dbSet;
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
