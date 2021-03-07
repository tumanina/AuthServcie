using AuthService.Client.Interfaces;
using AuthService.Client.Models;
using AuthService.Common.Interfaces.Services;
using System.Threading.Tasks;

namespace AuthService.Client
{
    public class AuthorizationClient : BaseClient, IAuthorizationClient
    {
        public async Task<BaseDataModel<TokenModel>> Login(string username, string password)
        {
            return await Execute<TokenModel>($"accounts", new LoginModel { UserName = username, Password = password });
        }

        public async Task<BaseDataModel<bool>> UserHasAccess(string username, string action)
        {
            return await Execute<bool>($"access?username={username}&action={action}");
        }
    }
}
