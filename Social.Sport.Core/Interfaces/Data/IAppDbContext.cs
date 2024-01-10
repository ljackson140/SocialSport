
using Microsoft.EntityFrameworkCore;
using Social.Sport.Core.Entities;

namespace Social.Sport.Core.Interfaces.Data
{
    public interface IAppDbContext
    {
        DbSet<User> Users { get; }
        DbSet<Team> Teams { get; }
    }
}
