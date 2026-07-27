namespace PROGEM.Domain.ValueObjects;

public class DataIntervalo
{
    public DateTime DataInicio { get; }
    public DateTime DataFim { get; }

    private DataIntervalo(DateTime inicio, DateTime fim)
    {
        DataInicio = inicio;
        DataFim = fim;
    }

    public static DataIntervalo Create(DateTime inicio, DateTime fim)
    {
        if (fim < inicio)
            throw new DomainException("Data final must be after data inicial.");

        if (inicio < DateTime.MinValue.AddYears(1900))
            throw new DomainException("Data inicial is out of valid range.");

        return new DataIntervalo(inicio, fim);
    }

    public int DiasUteis()
    {
        var count = 0;
        var current = DataInicio;
        while (current <= DataFim)
        {
            if (current.DayOfWeek != DayOfWeek.Saturday && current.DayOfWeek != DayOfWeek.Sunday)
                count++;
            current = current.AddDays(1);
        }
        return count;
    }

    public override string ToString() => $"{DataInicio:yyyy-MM-dd} to {DataFim:yyyy-MM-dd}";
}