using DinnerParty.Application.Interfaces.Persistence;
using DinnerParty.Contracts;
using DinnerParty.Domain.Entities;

namespace DinnerParty.Application.Services;

internal class DinnerService : IDinnerService
{
    private readonly IAggregateRepository<Dinner> _repository;

    public DinnerService(IAggregateRepository<Dinner> repository)
    {
        _repository = repository;
    }

    public async Task<ApiResponse<DinnerResult>> Create(string description, string location, DateTimeOffset date)
    {
        var dinner = new Dinner(description, location, date);

        await _repository.Create(dinner);

        return ApiResponse<DinnerResult>.Ok(
            new DinnerResult(dinner.Description, dinner.Location, dinner.Date));
    }

    public async Task<ApiResponse<DinnerResult>> GetById(Guid id)
    {
        var dinner = await _repository.GetById(id);

        if (dinner is null)
            return ApiResponse<DinnerResult>.Error("Not found");

        return ApiResponse<DinnerResult>.Ok(
            new DinnerResult(
                dinner.Description,
                dinner.Location,
                dinner.Date));
    }
}
