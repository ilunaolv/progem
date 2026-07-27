namespace PROGEM.Domain.ValueObjects;

public class RF
{
    public string Valor { get; }

    private RF(string valor)
    {
        Valor = valor;
    }

    public static RF Create(string rf)
    {
        if (string.IsNullOrWhiteSpace(rf))
            throw new DomainException("RF cannot be empty.");

        var digits = new string(rf.Where(char.IsDigit).ToArray());
        if (digits.Length < 7 || digits.Length > 9)
            throw new DomainException("RF must have between 7 and 9 digits.");

        return new RF(rf.Trim());
    }

    public override bool Equals(object? obj) => obj is RF other && Valor == other.Valor;
    public override int GetHashCode() => Valor.GetHashCode();
    public override string ToString() => Valor;
}