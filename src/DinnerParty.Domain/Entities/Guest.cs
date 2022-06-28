namespace DinnerParty.Domain.Entities;

public class Guest
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public bool Confirmed { get; private set; }

    public Guest(string name, bool confirmed)
    {
        Id = Guid.NewGuid();
        Name = name;
        Confirmed = confirmed;
    }
}
