
using Social.Sport.API.Helper;
using Social.Sport.Core.Entities;

namespace Social.Sport.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<Result<User>> AddAsync(User user, CancellationToken cancellationToken);
        Task<Result<User>> UpdateAsync(User user, CancellationToken cancellationToken);
        Task<Result<User>> UpdateUserPassword(User user, CancellationToken cancellationToken);
    }
}
