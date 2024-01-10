

namespace Social.Sport.Core.Interfaces.Services
{
    public interface ILogService
    {
        void Warning (string message);
        void Error (string message);
        void Error (Exception exception);
        void Error(Exception exception, string message);
    }
}
