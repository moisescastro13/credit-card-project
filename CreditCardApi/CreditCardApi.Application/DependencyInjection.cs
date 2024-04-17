using Microsoft.Extensions.DependencyInjection;


namespace CreditCardApi.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
       // services.AddAutoMapper(Assembly.GetExecutingAssembly());

       // services.AddScoped<IPasswordHasher, PasswordHasher>();
      //  services.AddScoped<ILoginService, LoginService>();
      //  services.AddScoped<IUserRegisterService, UserRegisterService>();
        //services.AddScoped<ICreateBoxSavingService, CreateBoxSavingService>();
        return services;
    }
}
