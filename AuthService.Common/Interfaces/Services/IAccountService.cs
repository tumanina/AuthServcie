using AuthService.Common.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthService.Common.Interfaces.Services
{
    public interface IAccountService
    {
        Task<AccountModel> GetByUsernameAsync(string username);
        Task<AccountModel> GetAccountAsync(Guid id);
        Task<AccountModel> GetAccountAsync(string username, string password);
        Task<AccountModel> CreateAccount(string username, string password, IEnumerable<Guid> actionIds);
        Task AddActionsToAccount(Guid accountId, IEnumerable<Guid> actionIds);
    }
}
