using MediatR;
using PROGEM.Domain.Entities;
using PROGEM.Domain.Interfaces;
using PROGEM.Shared;

namespace PROGEM.Application.Handlers;

public class RegistrarEncerramentoHandler : IRequestHandler<RegistrarEncerramentoCommand, ProcessoDto>
{
    private readonly IProcessoRepository _processoRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RegistrarEncerramentoHandler(IProcessoRepository processoRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _processoRepository = processoRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ProcessoDto> Handle(RegistrarEncerramentoCommand request, CancellationToken cancellationToken)
    {
        var processo = await _processoRepository.GetByIdAsync(request.ProcessoId, cancellationToken)
            ?? throw new NotFoundException($"Processo com Id {request.ProcessoId} nao encontrado.");

        processo.RegistrarEncerramento(request.DataEncerramento, request.Motivo);
        await _processoRepository.UpdateAsync(processo, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<ProcessoDto>(processo);
    }
}