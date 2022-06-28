namespace DinnerParty.Domain.Entities;

public class Dinner : IAggregateRoot
{
    public Guid Id { get; private set; }
    public string Description { get; private set; }
    public string Location { get; private set; }
    public DateTimeOffset Date { get; private set; }

    public ICollection<Guest> Guests { get; private set; } = new List<Guest>();

    public Dinner(string description, string location, DateTimeOffset date)
    {
        Id = Guid.NewGuid();
        Description = description;
        Location = location;
        Date = date;
    }
}
