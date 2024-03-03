
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Social.Sport.API.Helper;
using Social.Sport.Core.Entities.NotMapped;
using Social.Sport.Core.Interfaces.Data;
using Social.Sport.Core.Interfaces.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Social.Sport.Core.Services
{
    public class AuthenticateTokenService : BaseService, IAuthenticateTokenService
    {
        private readonly IConfiguration _configuration;

        public AuthenticateTokenService(IConfiguration configuration, IUnitOfWork unitOfWork, ILogger<BaseService> logger) : base(unitOfWork, logger) 
        {
            _configuration = configuration ?? throw new ArgumentNullException();
        }

        public async Task<Result<UserAuthenticationTicket>> AuthenticateAsync(string email, string password, CancellationToken cancellationToken)
        {
            var secretkey = _configuration[Constants.ConstantConfig.AuthenticateTokenMessages.SecretKey];
            var user = await _unitOfWork.Users.Get().FirstOrDefaultAsync(x => x.Email == email, cancellationToken);

            if (email != user?.Email)
            {
                return new ErrorResult<UserAuthenticationTicket>("This Email doesn't exist.");
                
            }
            if (password != user?.Password)
            {
                return new ErrorResult<UserAuthenticationTicket>("Invalid password.");
            }
            if (string.IsNullOrWhiteSpace(secretkey))
            {
                return new ErrorResult<UserAuthenticationTicket>("Authenticate miss configuration");
            }

            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretkey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claimsForToken = new List<Claim>
            {
                new Claim(Constants.ConstantConfig.AuthenticateTokenMessages.userId, user.Id.ToString()),
                new Claim(Constants.ConstantConfig.AuthenticateTokenMessages.userName, user.FirstName),
                new Claim(Constants.ConstantConfig.AuthenticateTokenMessages.userFamilyName, user.LastName),

            };

            var jwtSecurityToken = new JwtSecurityToken(
                _configuration[Constants.ConstantConfig.AuthenticateTokenMessages.Issuer],
                _configuration[Constants.ConstantConfig.AuthenticateTokenMessages.Audience],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                signingCredentials);

            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            var response = new UserAuthenticationTicket { AccessToken = token, User = user };
            return new SuccessResult<UserAuthenticationTicket>(response);
        }
    }
}
