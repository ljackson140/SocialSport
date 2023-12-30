namespace Social.Sport.Core.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChanges();
        Task CancelAsync();
    }
}
