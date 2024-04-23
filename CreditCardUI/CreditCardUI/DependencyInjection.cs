using CreditCardUI.Interfaces;
using CreditCardUI.Models.Configuration;
using CreditCardUI.Services;

namespace CreditCardUI;

public static class DependencyInjection
{
    public static IServiceCollection AddGlobalConfiguration(this IServiceCollection services, IConfiguration configuration)
    {

        var urisConfig = configuration.GetRequiredSection("Uris").Get<UrisServicesModel>()!;

        services.AddHttpClient("Api", client =>
        {
            client.BaseAddress = new Uri(urisConfig.ApiUrl);
        });
        services.AddHttpClient("Reports", client =>
        {
            client.BaseAddress = new Uri(urisConfig.ReporServiceUrl);
        });

        services.AddScoped<ICreditCardService, CreditCardService>()
            .AddScoped<ITransactionService, TransactionService>();

        return services;
    }
}
