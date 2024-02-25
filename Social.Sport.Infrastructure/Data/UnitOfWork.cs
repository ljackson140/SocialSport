using Social.Sport.Core.Entities;
using Social.Sport.Core.Interfaces.Data;

namespace Social.Sport.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext Context { get; set; }

        public IRepository<User> Users
        {
            get => new Repository<User>(Context);
        }

        public IRepository<Team> Teams
        {
            get => new Repository<Team>(Context);
        }

        public UnitOfWork(AppDbContext context) 
        { 
            Context = context;
        }

        public Task<int> SaveChanges()
        {
            return Context.SaveChangesAsync();
        }
        public Task CancelAsync()
        {
            throw new NotImplementedException();
        }
    }
}
