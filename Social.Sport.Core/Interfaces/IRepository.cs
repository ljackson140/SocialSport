using Social.Sport.Core.Entities;

namespace Social.Sport.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        public void AddAsync (TEntity entity, CancellationToken cancellation);
        public void Remove(TEntity entity);
        IQueryable<TEntity> Get();
    }
}
