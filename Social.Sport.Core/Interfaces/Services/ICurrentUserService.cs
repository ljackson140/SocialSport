
namespace Social.Sport.Core.Interfaces.Services
{
    public interface ICurrentUserService
    {
        public bool? IsAuthenticated { get; }
        public string UserName { get; }
        public string[]? Roles { get; }
    }
}
