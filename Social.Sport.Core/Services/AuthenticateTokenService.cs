
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Social.Sport.API.Helper;
using Social.Sport.Core.Entities.NotMapped;
using Social.Sport.Core.Interfaces.Data;
using Social.Sport.Core.Interfaces.Services;

namespace Social.Sport.Core.Services
{
   /* public class AuthenticateTokenService : BaseService, IAuthenticateTokenService
    {
        private readonly IConfiguration _configuration;

        public AuthenticateTokenService(IConfiguration configuration, IUnitOfWork unitOfWork, ILogger<BaseService> logger) : base(unitOfWork, logger) 
        {
            _configuration = configuration ?? throw new ArgumentNullException();
        }

        public async Task<Result<UserAuthenticationTicket>> AuthenticateAsync(string email, string password, CancellationToken cancellationToken)
        {
            var secretkey = _configuration[Constants.ConstantConfig.AuthenticateTokenMessages.SecretKey];
            //var user = await _unitOfWork.
            return secretkey;
            
        }
    }*/
}
