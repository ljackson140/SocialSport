

using Microsoft.Extensions.Logging;
using Social.Sport.API.Helper;
using Social.Sport.Core.Entities;
using Social.Sport.Core.Interfaces.Data;
using Social.Sport.Core.Interfaces.Services;

namespace Social.Sport.Core.Services
{
    public class TeamService : BaseService, ITeamService
    {
        public TeamService(IUnitOfWork unitOfWork, ILogger<BaseService> logger) : base(unitOfWork, logger)
        {
        }

        public Task<Result<Team>> AddAsync(Team Team, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Team>> UpdateAsync(Team Team, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

    }
}
