using DinnerParty.Application.Interfaces.Persistence;
using DinnerParty.Domain.Entities;
using DinnerParty.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace DinnerParty.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IAggregateRepository<Dinner>, DinnerRepository>();
        return services;
    }
}
