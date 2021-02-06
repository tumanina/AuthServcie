using Microsoft.EntityFrameworkCore;
using AuthService.Dal.DbContexts;
using AuthService.Dal.Entities;
using AuthService.Dal.Mappers;
using AuthService.Common.Interfaces.DalServices;
using AuthService.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Dal.Services
{
    public class AccountDalService : IAccountDalService
    {
        private readonly AuthDbContext _dbContext;

        public AccountDalService(AuthDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AccountModel> GetAccountAsync(Guid id)
        {
            var account = await _dbContext.Accounts.Where(e => e.Id == id)
                .Include(a => a.Actions).ThenInclude(c => c.Action)
                .FirstOrDefaultAsync();
            return account.Map();
        }

        public async Task<AccountModel> GetAccountAsync(string username, string password)
        {
            var account = await _dbContext.Accounts.Where(e => e.Username == username && e.Password == password)
                .Include(a => a.Actions).ThenInclude(c => c.Action)
                .FirstOrDefaultAsync();

            return account == null ? null : account.Map();
        }

        public async Task<AccountModel> GetByUsernameAsync(string username)
        {
            var account = await _dbContext.Accounts.Where(a => a.Username == username)
                .Include(a => a.Actions).ThenInclude(c => c.Action)
                .FirstOrDefaultAsync();

            return account?.Map();
        }

        public async Task<AccountModel> CreateAccountAsync(string username, string password, IEnumerable<Guid> actionIds)
        {
            var entity = new AccountEntity { Username = username, Password = password };
            entity.CreatedDate = DateTime.UtcNow;
            _dbContext.Accounts.Add(entity);
            _dbContext.AccountActions.AddRange(actionIds.Select(id => new AccountActionEntity { AccountId = entity.Id, ActionId = id }));

            await _dbContext.SaveChangesAsync();

            return entity.Map();
        }

        public async Task AddActionsToAccountAsync(Guid accountId, IEnumerable<Guid> actionIds)
        {
            _dbContext.AccountActions.AddRange(actionIds.Select(id => new AccountActionEntity { AccountId = accountId, ActionId = id }));
            await _dbContext.SaveChangesAsync();
        }
    }
}
