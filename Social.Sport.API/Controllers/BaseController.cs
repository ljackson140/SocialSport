using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using System.Net;
using Social.Sport.API.Helper;

namespace Social.Sport.API.Controllers
{
    [Authorize]
    public abstract class BaseController : ControllerBase
    {
        protected readonly IMapper _mapper;

        public BaseController(IMapper mapper)
        {
            _mapper = mapper;
        }

        protected IActionResult Error(Result result, HttpStatusCode statusCode)
        {
            if(result is IErrorResult errorResult)
            {
                return StatusCode((int) statusCode, new ErrorResult(errorResult.Message));
            }
            else
            {
                return StatusCode((int)statusCode, new ErrorResult("Unknown"));
            }
        }

        protected IActionResult Error(string errorMessage, HttpStatusCode statusCode)
        {
            return StatusCode((int)statusCode, new ErrorResult(errorMessage));
        }
    }
}
