using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AuthService.Web.Models;
using System.Threading.Tasks;
using AuthService.Common.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;

namespace AuthService.Web.Controllers
{
    [Route("api/v1/account")]
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;

        public AccountController(ILogger<AccountController> logger, IAccountService accountService)
            :base(logger)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<BaseApiDataModel<AccountApiModel>> Get(string userName, string password)
        {
            return await Execute(async () =>
            {
                var account = await _accountService.GetAccountAsync(userName, password);
                return account == null ? null : new AccountApiModel { Id = account.Id, UserName = account.Username };
            });
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<BaseApiDataModel<AccountApiModel>> Get(Guid id)
        {
            return await Execute(async () =>
            {
                var account = await _accountService.GetAccountAsync(id);
                return account == null ? null : new AccountApiModel { Id = account.Id, UserName = account.Username };
            });
        }

        [HttpPost]
        public async Task<BaseApiDataModel<Guid?>> Create(CreateAccountRequestModel accountModel)
        {
            return await Execute(async () =>
            {
                var account = await _accountService.CreateAccount(accountModel.UserName, accountModel.Password, new List<Guid>());
                return account?.Id;
            });
        }
    }
}
