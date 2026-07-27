namespace PROGEM.Application.DTOs;

public class ServidorDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string RF { get; set; } = string.Empty;
    public string Cargo { get; set; } = string.Empty;
    public string Secretaria { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? Telefone { get; set; }
    public bool Ativo { get; set; }
    public DateTime CriadoEm { get; set; }
    public DateTime AtualizadoEm { get; set; }
}