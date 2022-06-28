namespace DinnerParty.Contracts.Dinner;

public record DinnerRequest(string Description, string Location, DateTimeOffset Date);
