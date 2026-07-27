using AutoMapper;

namespace PROGEM.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Domain.Entities.Processo, DTOs.ProcessoDto>().ReverseMap();
        CreateMap<Domain.Entities.Envolvido, DTOs.EnvolvidoDto>().ReverseMap();
        CreateMap<Domain.Entities.Tramitacao, DTOs.TramitacaoDto>().ReverseMap();
        CreateMap<Domain.Entities.Prorrogacao, DTOs.ProrrogacaoDto>().ReverseMap();
        CreateMap<Domain.Entities.Historico, DTOs.HistoricoDto>().ReverseMap();
        CreateMap<Domain.Entities.Documento, DTOs.DocumentoDto>().ReverseMap();
        CreateMap<Domain.Entities.Servidor, DTOs.ServidorDto>().ReverseMap();
    }
}