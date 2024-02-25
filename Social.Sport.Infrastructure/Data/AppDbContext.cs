using Microsoft.EntityFrameworkCore;
using Social.Sport.Core.Entities;
using Social.Sport.Core.Interfaces;
using Social.Sport.Core.Interfaces.Data;
using Social.Sport.Core.Interfaces.Services;
using Social.Sport.Infrastructure.Converters;
using System.Reflection;

namespace Social.Sport.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {   }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
