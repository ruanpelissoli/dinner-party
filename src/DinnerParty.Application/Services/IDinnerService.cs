using DinnerParty.Contracts;

namespace DinnerParty.Application.Services;

public interface IDinnerService
{
    Task<ApiResponse<DinnerResult>> Create(string description, string location, DateTimeOffset date);
    Task<ApiResponse<DinnerResult>> GetById(Guid id);
}