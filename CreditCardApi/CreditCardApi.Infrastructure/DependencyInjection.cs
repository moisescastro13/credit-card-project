using CreditCardApi.Infrastructure.Interfaces;
using CreditCardApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CreditCardApi.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        //services.ConfigureJwt(configuration);
        //services.AddScoped<IJWTTokenService, JwtServiceManage>();

        return services;
    }
}
