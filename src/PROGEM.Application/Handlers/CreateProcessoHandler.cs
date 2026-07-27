using MediatR;
using PROGEM.Domain.Entities;
using PROGEM.Domain.Enums;
using PROGEM.Domain.Interfaces;
using PROGEM.Domain.ValueObjects;
using PROGEM.Shared;

namespace PROGEM.Application.Handlers;

public class CreateProcessoHandler : IRequestHandler<CreateProcessoCommand, ProcessoDto>
{
    private readonly IProcessoRepository _processoRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateProcessoHandler(IProcessoRepository processoRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _processoRepository = processoRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ProcessoDto> Handle(CreateProcessoCommand request, CancellationToken cancellationToken)
    {
        var numero = NumeroProcesso.Create(request.Numero);
        var processo = Processo.Criar(
            numero,
            request.Ano,
            request.Codigo,
            request.Anexo,
            request.Volume,
            request.Natureza,
            request.Categoria,
            request.Subcategoria,
            request.Requerente,
            request.Local,
            request.Tipo,
            request.Assunto,
            request.DataIrregularidade,
            request.Observacoes
        );

        await _processoRepository.AddAsync(processo, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<ProcessoDto>(processo);
    }
}