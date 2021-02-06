using AuthService.Common.Models;
using System.Threading.Tasks;

namespace AuthService.Common.Interfaces.Services
{
    public interface IAuthorizationService
    {
        Task<TokenModel> Login(string username, string action);
        bool UserHasAccess(AccountModel account, string action);
        Task<bool> UserHasAccess(string username, string action);
    }
}
