

using Social.Sport.API.Helper;
using Social.Sport.Core.Entities;

namespace Social.Sport.Core.Interfaces.Services
{
    public interface ISignUpInfoService
    {
        Task<Result<User>> SignUpAsync(User user, CancellationToken cancellationToken);
        Task<Result<User>> UnitUserAsync(int userId, CancellationToken cancellationToken);
    }
}
