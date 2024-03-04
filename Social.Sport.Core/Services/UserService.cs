using Microsoft.Extensions.Logging;
using Social.Sport.API.Helper;
using Social.Sport.Core.Entities;
using Social.Sport.Core.Interfaces.Data;
using Social.Sport.Core.Interfaces.Services;

namespace Social.Sport.Core.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IUnitOfWork unitOfWork, ILogger<BaseService> logger) : base(unitOfWork, logger)
        {
        }

        public async Task<Result<User>> AddAsync(User user, CancellationToken cancellationToken)
        {
            _unitOfWork.Users.AddAsync(user, cancellationToken);
            await _unitOfWork.SaveChanges();
            return new SuccessResult<User>(user);
        }

        public Task<Result<User>> UpdateAsync(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Result<User>> UpdateUserPassword(User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
