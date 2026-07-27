using PROGEM.Domain.Entities;
using PROGEM.Domain.Interfaces;
using System.Linq.Expressions;

namespace PROGEM.Infrastructure.Repositories;

public class HistoricoRepository : EfRepository<Historico>, IHistoricoRepository
{
    public HistoricoRepository(PROGEMDbContext context) : base(context) { }

    public async Task<IReadOnlyList<Historico>> FindByProcessoAsync(Guid processoId, CancellationToken cancellationToken = default)
    {
        return await _dbSet.Where(h => h.ProcessoId == processoId).ToListAsync(cancellationToken);
    }
}