using PROGEM.Domain.Entities;
using PROGEM.Domain.Interfaces;

namespace PROGEM.Infrastructure.Repositories;

public class ServidorRepository : EfRepository<Servidor>, IServidorRepository
{
    public ServidorRepository(PROGEMDbContext context) : base(context) { }
}