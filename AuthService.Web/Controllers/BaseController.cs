using AuthService.Common.Extensions;
using AuthService.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthService.Web.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        private readonly ILogger<ControllerBase> _logger;

        public BaseController(ILogger<ControllerBase> logger)
        {
            _logger = logger;
        }

        internal async Task<BaseApiDataModel<T>> Execute<T>(Func<Task<T>> func)
        {
            try
            {
                var data = await func();
                return new BaseApiDataModel<T> { Data = data };
            }
            catch (UnauthorizedAccessException ex)
            {
                HttpContext.Response.StatusCode = 401;
                return new BaseApiDataModel<T> { Errors = new List<string> { ex.GetMessage() } };
            }
            catch (Exception ex)
            {
                var errorMessage = ex.GetMessage();
                _logger.LogError(errorMessage);
                return new BaseApiDataModel<T> { Errors = new List<string> { errorMessage } };
            }
        }

        internal async Task<BaseApiModel> Execute(Func<Task> func)
        {
            try
            {
                await func();
                return new BaseApiModel();
            }
            catch (Exception ex)
            {
                var errorMessage = ex.GetMessage();
                _logger.LogError(errorMessage);
                return new BaseApiModel { Errors = new List<string> { errorMessage } };
            }
        }
    }
}
