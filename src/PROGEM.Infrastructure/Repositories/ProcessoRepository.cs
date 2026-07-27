using PROGEM.Domain.Entities;
using PROGEM.Domain.Interfaces;

namespace PROGEM.Infrastructure.Repositories;

public class ProcessoRepository : EfRepository<Processo>, IProcessoRepository
{
    public ProcessoRepository(PROGEMDbContext context) : base(context) { }
}