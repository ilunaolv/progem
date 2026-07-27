using MediatR;
using PROGEM.Domain.Entities;
using PROGEM.Domain.Interfaces;
using PROGEM.Shared;

namespace PROGEM.Application.Handlers;

public class GetEnvolvidosByProcessoHandler : IRequestHandler<GetEnvolvidosByProcessoQuery, List<EnvolvidoDto>>
{
    private readonly IEnvolvidoRepository _envolvidoRepository;
    private readonly IMapper _mapper;

    public GetEnvolvidosByProcessoHandler(IEnvolvidoRepository envolvidoRepository, IMapper mapper)
    {
        _envolvidoRepository = envolvidoRepository;
        _mapper = mapper;
    }

    public async Task<List<EnvolvidoDto>> Handle(GetEnvolvidosByProcessoQuery request, CancellationToken cancellationToken)
    {
        var envolvidos = await _envolvidoRepository.FindAsync(e => e.ProcessoId == request.ProcessoId, cancellationToken);
        return _mapper.Map<List<EnvolvidoDto>>(envolvidos);
    }
}