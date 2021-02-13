using AuthService.Client.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthService.Client.Interfaces
{
    public interface IAccountClient : IBaseClient
    {
        Task<BaseDataModel<AccountModel>> GetAccountAsync(Guid id);
        Task<BaseDataModel<AccountModel>> GetAccountAsync(string username, string password);
        Task<BaseDataModel<Guid>> CreateAccount(CreateAccountModel account);
    }
}
