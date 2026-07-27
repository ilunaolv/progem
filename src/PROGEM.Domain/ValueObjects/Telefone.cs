namespace PROGEM.Domain.ValueObjects;

public class Telefone
{
    public string Value { get; }

    private Telefone(string value)
    {
        Value = value;
    }

    public static Telefone Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException("Telefone cannot be empty.");

        var digits = new string(value.Where(char.IsDigit).ToArray());
        if (digits.Length < 10 || digits.Length > 11)
            throw new DomainException("Telefone must have 10 or 11 digits.");

        return new Telefone(value.Trim());
    }

    public override bool Equals(object? obj) => obj is Telefone other && Value == other.Value;
    public override int GetHashCode() => Value.GetHashCode();
    public override string ToString() => Value;
}