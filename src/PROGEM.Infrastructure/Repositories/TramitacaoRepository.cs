using PROGEM.Domain.Entities;
using PROGEM.Domain.Interfaces;
using System.Linq.Expressions;

namespace PROGEM.Infrastructure.Repositories;

public class TramitacaoRepository : EfRepository<Tramitacao>, ITramitacaoRepository
{
    public TramitacaoRepository(PROGEMDbContext context) : base(context) { }

    public async Task<IReadOnlyList<Tramitacao>> FindByProcessoAsync(Guid processoId, CancellationToken cancellationToken = default)
    {
        return await _dbSet.Where(t => t.ProcessoId == processoId).ToListAsync(cancellationToken);
    }
}