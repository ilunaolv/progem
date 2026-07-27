namespace PROGEM.Domain.ValueObjects;

public class NumeroProcesso
{
    public string Valor { get; }

    private NumeroProcesso(string valor)
    {
        Valor = valor;
    }

    public static NumeroProcesso Create(string numero)
    {
        if (string.IsNullOrWhiteSpace(numero))
            throw new DomainException("Número do processo cannot be empty.");

        if (numero.Length < 4 || numero.Length > 20)
            throw new DomainException("Número do processo must be between 4 and 20 characters.");

        return new NumeroProcesso(numero.Trim().ToUpperInvariant());
    }

    public override bool Equals(object? obj) => obj is NumeroProcesso other && Valor == other.Valor;
    public override int GetHashCode() => Valor.GetHashCode();
    public override string ToString() => Valor;
}