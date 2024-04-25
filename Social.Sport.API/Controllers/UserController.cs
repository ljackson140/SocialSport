using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Social.Sport.API.Middlewares;
using Social.Sport.Core.Interfaces.Services;

namespace Social.Sport.API.Controllers
{

    [Route("api/users")]
    [ApiController]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public class UserController : BaseController
    {
        private readonly IAuthenticateTokenService _authenticateTokenService;
        private readonly ISignUpInfoService _signUpInfoService;
        private readonly IUserService _userService;

        public UserController(IMapper mapper, IAuthenticateTokenService authenticateTokenService, ISignUpInfoService signupInfo, IUserService userService) : base(mapper)
        {
            _authenticateTokenService = authenticateTokenService;
            _signUpInfoService = signupInfo;
            _userService = userService;
        }
    }
}
