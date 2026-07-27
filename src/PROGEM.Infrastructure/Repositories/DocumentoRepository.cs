using PROGEM.Domain.Entities;
using PROGEM.Domain.Interfaces;
using System.Linq.Expressions;

namespace PROGEM.Infrastructure.Repositories;

public class DocumentoRepository : EfRepository<Documento>, IDocumentoRepository
{
    public DocumentoRepository(PROGEMDbContext context) : base(context) { }

    public async Task<IReadOnlyList<Documento>> FindByProcessoAsync(Guid processoId, CancellationToken cancellationToken = default)
    {
        return await _dbSet.Where(d => d.ProcessoId == processoId).ToListAsync(cancellationToken);
    }
}