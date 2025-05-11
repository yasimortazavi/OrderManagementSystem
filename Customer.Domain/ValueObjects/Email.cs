namespace Customer.Domain.ValueObjects;

public class Email
{
    public string Value { get; private set; }

    private Email() { } // For EF

    public Email(string value)
    {
        if (!IsValid(value))
            throw new ArgumentException("Invalid email address.");

        Value = value;
    }

    public static bool IsValid(string email) =>
        !string.IsNullOrWhiteSpace(email) &&
        email.Contains("@") &&
        email.Contains(".");

    public override bool Equals(object? obj) =>
        obj is Email other && Value == other.Value;

    public override int GetHashCode() => Value.GetHashCode();

    public override string ToString() => Value;
}
