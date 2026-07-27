using MediatR;
using PROGEM.Domain.Entities;
using PROGEM.Domain.Interfaces;
using PROGEM.Shared;

namespace PROGEM.Application.Handlers;

public class GetProcessoByIdHandler : IRequestHandler<GetProcessoByIdQuery, ProcessoDto?>
{
    private readonly IProcessoRepository _processoRepository;
    private readonly IMapper _mapper;

    public GetProcessoByIdHandler(IProcessoRepository processoRepository, IMapper mapper)
    {
        _processoRepository = processoRepository;
        _mapper = mapper;
    }

    public async Task<ProcessoDto?> Handle(GetProcessoByIdQuery request, CancellationToken cancellationToken)
    {
        var processo = await _processoRepository.GetByIdAsync(request.Id, cancellationToken);
        return processo is null ? null : _mapper.Map<ProcessoDto>(processo);
    }
}