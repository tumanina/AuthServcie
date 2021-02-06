using AuthService.Common.Interfaces.Security;
using AuthService.Common.Interfaces.Services;
using AuthService.Common.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Logic.Authentification
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IAccountService _accountService;
        private readonly IJwtTokenService _tokenService; 

        public AuthorizationService(IAccountService accountService, IJwtTokenService tokenService)
        {
            _accountService = accountService;
            _tokenService = tokenService;
        }

        public async Task<TokenModel> Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                throw new UnauthorizedAccessException("Required parameter is null or empty");
            }

            var account = await _accountService.GetAccountAsync(username.ToLower(), password);

            if (account == null)
            {
                throw new UnauthorizedAccessException("User with this name and password not found");
            }

            return _tokenService.GenerateToken(account.Username);
        }

        public bool UserHasAccess(AccountModel account, string action)
        {
            action = action?.ToLower() ?? string.Empty;
            return account.Actions.Any(c => c.Name.Equals(action, StringComparison.InvariantCultureIgnoreCase));
        }

        public async Task<bool> UserHasAccess(string username, string action)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(action))
            {
                throw new Exception("Required parameter is null or empty");
            }

            var account = await _accountService.GetByUsernameAsync(username.ToLower());
            return account.Actions.Any(c => c.Name.Equals(action, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
