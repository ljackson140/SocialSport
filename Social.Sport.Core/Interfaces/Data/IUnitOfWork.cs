namespace Social.Sport.Core.Interfaces.Data
{
    public interface IUnitOfWork
    {
        Task<int> SaveChanges();
        Task CancelAsync();
    }
}
