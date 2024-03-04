

using Social.Sport.API.Helper;
using Social.Sport.Core.Entities;

namespace Social.Sport.Core.Interfaces.Services
{
    public interface ITeamService
    {
        Task<Result<Team>> AddAsync(Team Team, CancellationToken cancellationToken);
        Task<Result<Team>> UpdateAsync(Team Team, CancellationToken cancellationToken);
        Task<Result<IList<Team>>> GetAllAsync(Team Team, CancellationToken cancellationToken);
        Task<Result<Team>> DeleteAsync(Team TeamId, CancellationToken cancellationToken);
    }
}
