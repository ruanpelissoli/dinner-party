using DinnerParty.Domain;

namespace DinnerParty.Application.Interfaces.Persistence;

public interface IAggregateRepository<T> where T : IAggregateRoot
{
    Task<T> Create(T aggregate);
    Task<T?> GetById(Guid id);
}
