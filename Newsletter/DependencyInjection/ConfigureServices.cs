using Newsletter.Service;
using Newsletter.Service.Interfaces;

namespace Newsletter.DependencyInjection;

public static class ConfigureServices
{
    public static void Configure(IServiceCollection services)
    {
        services.AddTransient<ISubscriptionService, SubscriptionService>();
    }
}
