using MediatR;
using PROGEM.Domain.Entities;
using PROGEM.Domain.Interfaces;
using PROGEM.Shared;

namespace PROGEM.Application.Handlers;

public class CreateEnvolvidoHandler : IRequestHandler<CreateEnvolvidoCommand, EnvolvidoDto>
{
    private readonly IEnvolvidoRepository _envolvidoRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateEnvolvidoHandler(IEnvolvidoRepository envolvidoRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _envolvidoRepository = envolvidoRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<EnvolvidoDto> Handle(CreateEnvolvidoCommand request, CancellationToken cancellationToken)
    {
        var envolvido = Envolvido.Criar(
            request.ProcessoId,
            request.ServidorId,
            request.Resultado,
            request.DiasSuspensao,
            request.Observacao
        );

        await _envolvidoRepository.AddAsync(envolvido, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<EnvolvidoDto>(envolvido);
    }
}