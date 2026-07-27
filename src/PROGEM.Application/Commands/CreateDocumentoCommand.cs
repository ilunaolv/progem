using MediatR;
using PROGEM.Domain.Enums;

namespace PROGEM.Application.Commands;

public record CreateDocumentoCommand(
    Guid ProcessoId,
    string Nome,
    string Caminho,
    TipoDocumento Tipo,
    long TamanhoBytes,
    string MimeType,
    string UploadedPor
) : IRequest<DocumentoDto>;