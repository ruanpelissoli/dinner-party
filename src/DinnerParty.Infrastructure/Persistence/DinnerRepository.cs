using DinnerParty.Application.Interfaces.Persistence;
using DinnerParty.Domain.Entities;

namespace DinnerParty.Infrastructure.Persistence;

internal class DinnerRepository : IAggregateRepository<Dinner>
{
    private static List<Dinner> Dinners { get; set; } = new List<Dinner>();

    public async Task<Dinner> Create(Dinner dinner)
    {
        Dinners.Add(dinner);

        return await Task.FromResult(dinner);
    }

    public async Task<Dinner?> GetById(Guid id)
    {
        return await Task.FromResult(Dinners.FirstOrDefault(d => d.Id == id));
    }
}
