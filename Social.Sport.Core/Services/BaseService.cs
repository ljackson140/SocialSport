

using Microsoft.Extensions.Logging;
using Social.Sport.Core.Interfaces.Data;

namespace Social.Sport.Core.Services
{
    public class BaseService
    {
        protected IUnitOfWork _unitOfWork;
        protected readonly ILogger<BaseService> _logger;

        public BaseService(IUnitOfWork unitOfWork, ILogger<BaseService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
    }
}
