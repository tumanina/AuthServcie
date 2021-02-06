using AuthService.Common.Interfaces.Security;
using AuthService.Common.Interfaces.Services;
using AuthService.Logic.Authentification;
using AuthService.Logic.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AuthService.Logic
{
    public static class Config
    {
        public static void ConfigureLogic(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();

            services.AddScoped<IAuthorizationService, AuthorizationService>();
            services.AddSingleton<IJwtTokenService, JwtTokenService>();
            services.AddSingleton<ISecurityService, Rs256SecurityService>();
            services.AddSingleton<ISecurityService, Hs256SecurityService>();
        }
    }
}
