using DinnerParty.Domain.Entities;

namespace DinnerParty.Application.Interfaces.Persistence;

public interface IDinnerRepository
{
    Task<Dinner> Create(Dinner dinner);
    Task<Dinner?> GetById(Guid id);
}
