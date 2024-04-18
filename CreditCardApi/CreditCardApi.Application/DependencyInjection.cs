using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CreditCardApi.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

       // services.AddScoped<IPasswordHasher, PasswordHasher>();
      //  services.AddScoped<ILoginService, LoginService>();
      //  services.AddScoped<IUserRegisterService, UserRegisterService>();
        //services.AddScoped<ICreateBoxSavingService, CreateBoxSavingService>();
        return services;
    }
}
