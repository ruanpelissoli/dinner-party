using DinnerParty.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DinnerParty.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IDinnerService, DinnerService>();

        return services;
    }
}
