using AuthService.Client.Interfaces;
using AuthService.Client.Models;
using AuthService.Common.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace AuthService.Client
{
    public class AccountClient : BaseClient, IAccountClient
    {
        public async Task<BaseDataModel<Guid>> CreateAccount(CreateAccountModel account)
        {
            return await Execute<Guid>($"accounts", account);
        }

        public async Task<BaseDataModel<AccountModel>> GetAccountAsync(Guid id)
        {
            return await Execute<AccountModel>($"accounts/{id}");
        }

        public async Task<BaseDataModel<AccountModel>> GetAccountAsync(string username, string password)
        {
            return await Execute<AccountModel>($"accounts?username={username}&password={password}");
        }
    }
}
