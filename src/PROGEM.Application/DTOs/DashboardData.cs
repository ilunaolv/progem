namespace PROGEM.Application.DTOs;

public class DashboardData
{
    public int TotalProcessos { get; set; }
    public int ProcessosAbertos { get; set; }
    public int ProcessosVencendo { get; set; }
    public int ProcessosAtrasados { get; set; }
    public int[] PorNatureza { get; set; } = new int[4];
    public int[] PorCategoria { get; set; } = new int[2];
}