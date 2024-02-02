

namespace Social.Sport.Core.Interfaces.Services
{
    public interface ILogService
    {
        void Warning (string message);
        void Failure(string message);
        void Failure(Exception exception);
        void Failure(Exception exception, string message);
    }
}
