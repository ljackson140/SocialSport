using Microsoft.EntityFrameworkCore;
using Social.Sport.Core.Entities;
using Social.Sport.Core.Interfaces;
using Social.Sport.Core.Interfaces.Data;
using Social.Sport.Core.Interfaces.Services;
using Social.Sport.Infrastructure.Converters;
using System.Reflection;

namespace Social.Sport.Infrastructure.Data
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        private ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;
        
        public AppDbContext(
            DbContextOptions<AppDbContext> options,
            ICurrentUserService userService,
            IDateTime dateTime) : base(options) 
        { 
            _currentUserService = userService;
            _dateTime = dateTime;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.ApplyUtcdateConverter();
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch(entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.UserName;
                        entry.Entity.CreatedDate = _dateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedBy = _currentUserService.UserName;
                        entry.Entity.UpdatedDate = _dateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
