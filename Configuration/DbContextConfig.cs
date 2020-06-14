using InvestCarWeb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InvestCarWeb.Configuration
{
    public static class DbContextConfig
    {
        public static IServiceCollection AddDbContextConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IdentyDbContext>(options =>
                options.UseMySql(configuration.GetConnectionString("IdentyDbContext"), builder =>
                builder.MigrationsAssembly("InvestCarWeb")));
            return services;
        }
    }
}