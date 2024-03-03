using Social.Sport.Core.Entities;

namespace Social.Sport.Core.Interfaces.Data
{
    public interface IUnitOfWork
    {
        IRepository<User> Users { get; }
        IRepository<Team> Teams { get; }
        Task<int> SaveChanges();
        Task CancelAsync();
    }
}
