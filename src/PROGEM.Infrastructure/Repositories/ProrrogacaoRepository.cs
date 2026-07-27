using PROGEM.Domain.Entities;
using PROGEM.Domain.Interfaces;
using System.Linq.Expressions;

namespace PROGEM.Infrastructure.Repositories;

public class ProrrogacaoRepository : EfRepository<Prorrogacao>, IProrrogacaoRepository
{
    public ProrrogacaoRepository(PROGEMDbContext context) : base(context) { }

    public async Task<IReadOnlyList<Prorrogacao>> FindByProcessoAsync(Guid processoId, CancellationToken cancellationToken = default)
    {
        return await _dbSet.Where(p => p.ProcessoId == processoId).ToListAsync(cancellationToken);
    }
}