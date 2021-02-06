using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AuthService.Web.Models;
using System.Threading.Tasks;
using AuthService.Common.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using IAuthorizationService = AuthService.Common.Interfaces.Services.IAuthorizationService;

namespace AuthService.Web.Controllers
{
    [Route("api/v1")]
    [AllowAnonymous]
    public class LoginController: BaseController
    {
        private readonly IAuthorizationService _authService;

        public LoginController(ILogger<LoginController> logger, IAuthorizationService authService)
            :base(logger)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<BaseApiDataModel<TokenApiModel>> Deploy(LoginRequestModel loginModel)
        {
            return await Execute(async () =>
            {
                var token = await _authService.Login(loginModel.UserName, loginModel.Password);

                return new TokenApiModel { Token = token.Token, ExpiredAt = token.ExpiredAt };
            });
        }
    }
}
