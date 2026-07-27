using MediatR;
using PROGEM.Domain.Entities;
using PROGEM.Domain.Interfaces;
using PROGEM.Shared;

namespace PROGEM.Application.Handlers;

public class CreateProrrogacaoHandler : IRequestHandler<CreateProrrogacaoCommand, ProrrogacaoDto>
{
    private readonly IProrrogacaoRepository _prorrogacaoRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateProrrogacaoHandler(IProrrogacaoRepository prorrogacaoRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _prorrogacaoRepository = prorrogacaoRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ProrrogacaoDto> Handle(CreateProrrogacaoCommand request, CancellationToken cancellationToken)
    {
        var prorrogacao = Prorrogacao.Criar(
            request.ProcessoId,
            request.QuantidadeDias,
            request.DataAnterior,
            request.NovaData,
            request.Motivo,
            request.Usuario
        );

        await _prorrogacaoRepository.AddAsync(prorrogacao, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<ProrrogacaoDto>(prorrogacao);
    }
}