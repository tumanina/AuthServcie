using AuthService.Client.Models;
using System.Threading.Tasks;

namespace AuthService.Client.Interfaces
{
    public interface IAuthorizationClient : IBaseClient
    {
        Task<BaseDataModel<TokenModel>> Login(string username, string password);
        Task<BaseDataModel<bool>> UserHasAccess(string username, string action);
    }
}
