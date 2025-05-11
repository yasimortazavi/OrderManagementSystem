using Customer.Domain.ValueObjects;

namespace Customer.Domain.Entities;

public class Customer
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public Email Email { get; private set; }

    private Customer() { } // For EF Core

    public Customer(Guid id, string name, Email email)
    {
        Id = id;
        SetName(name);
        Email = email ?? throw new ArgumentNullException(nameof(email));
    }

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.");

        Name = name;
    }
}
