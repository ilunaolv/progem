using PROGEM.Domain.Entities;
using PROGEM.Domain.Interfaces;
using System.Linq.Expressions;

namespace PROGEM.Infrastructure.Repositories;

public class EnvolvidoRepository : EfRepository<Envolvido>, IEnvolvidoRepository
{
    public EnvolvidoRepository(PROGEMDbContext context) : base(context) { }

    public async Task<IReadOnlyList<Envolvido>> FindByProcessoAsync(Guid processoId, CancellationToken cancellationToken = default)
    {
        return await _dbSet.Where(e => e.ProcessoId == processoId).ToListAsync(cancellationToken);
    }
}