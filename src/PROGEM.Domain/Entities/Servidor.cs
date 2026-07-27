using PROGEM.Domain.ValueObjects;

namespace PROGEM.Domain.Entities;

public class Servidor
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public RF RF { get; private set; }
    public string Cargo { get; private set; }
    public string Secretaria { get; private set; }
    public Email? Email { get; private set; }
    public Telefone? Telefone { get; private set; }
    public bool Ativo { get; private set; }
    public DateTime CriadoEm { get; private set; }
    public DateTime AtualizadoEm { get; private set; }

    private Servidor() { }

    public static Servidor Criar(string nome, RF rf, string cargo, string secretaria, Email? email, Telefone? telefone)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new DomainException("Servidor nome is required.");

        return new Servidor
        {
            Id = Guid.NewGuid(),
            Nome = nome,
            RF = rf,
            Cargo = cargo ?? throw new DomainException("Cargo is required."),
            Secretaria = secretaria ?? throw new DomainException("Secretaria is required."),
            Email = email,
            Telefone = telefone,
            Ativo = true,
            CriadoEm = DateTime.UtcNow,
            AtualizadoEm = DateTime.UtcNow
        };
    }

    public void Atualizar(string nome, string cargo, string secretaria, Email? email, Telefone? telefone)
    {
        Nome = nome ?? throw new DomainException("Nome is required.");
        Cargo = cargo ?? throw new DomainException("Cargo is required.");
        Secretaria = secretaria ?? throw new DomainException("Secretaria is required.");
        Email = email;
        Telefone = telefone;
        AtualizadoEm = DateTime.UtcNow;
    }

    public void Desativar()
    {
        Ativo = false;
        AtualizadoEm = DateTime.UtcNow;
    }

    public void Ativar()
    {
        Ativo = true;
        AtualizadoEm = DateTime.UtcNow;
    }
}