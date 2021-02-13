using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AuthService.Web.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using IAuthorizationService = AuthService.Common.Interfaces.Services.IAuthorizationService;

namespace AuthService.Web.Controllers
{
    [Route("api/v1/access")]
    [AllowAnonymous]
    public class AccessController : BaseController
    {
        private readonly IAuthorizationService _authService;

        public AccessController(ILogger<AccessController> logger, IAuthorizationService authService)
            :base(logger)
        {
            _authService = authService;
        }

        [HttpGet]
        public async Task<BaseApiDataModel<bool>> CheckAccess(string username, string action)
        {
            return await Execute(async () =>
            {
                return await _authService.UserHasAccess(username, action);
            });
        }
    }
}
