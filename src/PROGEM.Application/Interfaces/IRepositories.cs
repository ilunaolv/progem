namespace PROGEM.Application.Interfaces;

public interface IProcessoRepository
{
    Task<Processo?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Processo>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Processo>> FindAsync(System.Linq.Expressions.Expression<Func<Processo, bool>> predicate, CancellationToken cancellationToken = default);
    Task AddAsync(Processo entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(Processo entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(Processo entity, CancellationToken cancellationToken = default);
}

public interface IEnvolvidoRepository
{
    Task<Envolvido?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Envolvido>> FindByProcessoAsync(Guid processoId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Envolvido>> FindAsync(System.Linq.Expressions.Expression<Func<Envolvido, bool>> predicate, CancellationToken cancellationToken = default);
    Task AddAsync(Envolvido entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(Envolvido entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(Envolvido entity, CancellationToken cancellationToken = default);
}

public interface ITramitacaoRepository
{
    Task<Tramitacao?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Tramitacao>> FindByProcessoAsync(Guid processoId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Tramitacao>> FindAsync(System.Linq.Expressions.Expression<Func<Tramitacao, bool>> predicate, CancellationToken cancellationToken = default);
    Task AddAsync(Tramitacao entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(Tramitacao entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(Tramitacao entity, CancellationToken cancellationToken = default);
}

public interface IProrrogacaoRepository
{
    Task<Prorrogacao?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Prorrogacao>> FindByProcessoAsync(Guid processoId, CancellationToken cancellationToken = default);
    Task AddAsync(Prorrogacao entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(Prorrogacao entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(Prorrogacao entity, CancellationToken cancellationToken = default);
}

public interface IHistoricoRepository
{
    Task<Historico?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Historico>> FindByProcessoAsync(Guid processoId, CancellationToken cancellationToken = default);
    Task AddAsync(Historico entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(Historico entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(Historico entity, CancellationToken cancellationToken = default);
}

public interface IDocumentoRepository
{
    Task<Documento?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Documento>> FindByProcessoAsync(Guid processoId, CancellationToken cancellationToken = default);
    Task AddAsync(Documento entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(Documento entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(Documento entity, CancellationToken cancellationToken = default);
}

public interface IServidorRepository
{
    Task<Servidor?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Servidor>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Servidor>> FindAsync(System.Linq.Expressions.Expression<Func<Servidor, bool>> predicate, CancellationToken cancellationToken = default);
    Task AddAsync(Servidor entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(Servidor entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(Servidor entity, CancellationToken cancellationToken = default);
}