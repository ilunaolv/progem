using MediatR;
using PROGEM.Domain.Entities;
using PROGEM.Domain.Interfaces;
using PROGEM.Shared;

namespace PROGEM.Application.Handlers;

public class GetTramitacoesByProcessoHandler : IRequestHandler<GetTramitacoesByProcessoQuery, List<TramitacaoDto>>
{
    private readonly ITramitacaoRepository _tramitacaoRepository;
    private readonly IMapper _mapper;

    public GetTramitacoesByProcessoHandler(ITramitacaoRepository tramitacaoRepository, IMapper mapper)
    {
        _tramitacaoRepository = tramitacaoRepository;
        _mapper = mapper;
    }

    public async Task<List<TramitacaoDto>> Handle(GetTramitacoesByProcessoQuery request, CancellationToken cancellationToken)
    {
        var tramitacoes = await _tramitacaoRepository.FindAsync(t => t.ProcessoId == request.ProcessoId, cancellationToken);
        return _mapper.Map<List<TramitacaoDto>>(tramitacoes);
    }
}