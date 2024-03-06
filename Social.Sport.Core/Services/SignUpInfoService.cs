using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Social.Sport.API.Helper;
using Social.Sport.Core.Entities;
using Social.Sport.Core.Interfaces.Data;
using Social.Sport.Core.Interfaces.Services;
using static Social.Sport.Core.Constants.ConstantConfig;

namespace Social.Sport.Core.Services
{
    public class SignUpInfoService : BaseService, ISignupInfo
    {
        public SignUpInfoService(IUnitOfWork unitOfWork, ILogger<BaseService> logger) : base(unitOfWork, logger)
        {
        }

        public async Task<Result<User>> SignUpAsync(User user, CancellationToken cancellationToken)
        {
            var userExist = await _unitOfWork.Users.Get().FirstOrDefaultAsync(x => x.Email == user.Email, cancellationToken);
            if (user.Email == userExist?.Email)
            {
                return new ErrorResult<User>(ValidationMessages.MessageAccountExist);
            }
            else
            {
                _unitOfWork.Users.AddAsync(user, cancellationToken);
                await _unitOfWork.SaveChanges();
                return new SuccessResult<User>(user);
            }
        }

        public async Task<Result<User>> UnitUserAsync(int userId, CancellationToken cancellationToken)
        {
            var users = await _unitOfWork.Users.Get().ToListAsync(cancellationToken);
            var user = users.FirstOrDefault(x => x.Id == userId);
            return new SuccessResult<User>(user);
        }
    }
}
