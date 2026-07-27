using MediatR;
using PROGEM.Domain.Entities;
using PROGEM.Domain.Interfaces;

namespace PROGEM.Application.Handlers;

public class GetUserByEmailHandler : IRequestHandler<GetUserByEmailQuery, ServidorDto?>
{
    private readonly IServidorRepository _servidorRepository;
    private readonly IMapper _mapper;

    public GetUserByEmailHandler(IServidorRepository servidorRepository, IMapper mapper)
    {
        _servidorRepository = servidorRepository;
        _mapper = mapper;
    }

    public async Task<ServidorDto?> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        var servidor = await _servidorRepository.FindAsync(s => s.Email!.Value == request.Email, cancellationToken);
        return servidor is null ? null : _mapper.Map<ServidorDto>(servidor);
    }
}