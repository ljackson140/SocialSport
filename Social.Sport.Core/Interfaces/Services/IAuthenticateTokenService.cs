using Social.Sport.Core.Entities.NotMapped;
using Social.Sport.API.Helper;

namespace Social.Sport.Core.Interfaces.Services
{
    public interface IAuthenticateTokenService
    {
        Task<Result<UserAuthenticationTicket>> AuthenticateAsync(string email, string password, CancellationToken cancellationToken);
    }
}
