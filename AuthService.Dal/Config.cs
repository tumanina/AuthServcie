using AuthService.Common.Interfaces.DalServices;
using AuthService.Dal.DbContexts;
using AuthService.Dal.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AuthService.Dal
{
    public static class Config
    {
        public static void ConfigureDal(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AuthDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IAccountDalService, AccountDalService>();
        }
    }
}
