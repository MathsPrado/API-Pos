using AutoMapper;
using Student.API.Model;

namespace Student.API.DTOs.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SolicitacaoProjetoDTO, SolicitacaoProjeto>();
            CreateMap<SolicitacaoProjeto, SolicitacaoProjetoDTO>();
            CreateMap<PerfilUser, PerfilUserDTO>();

            CreateMap<PropostaSolicitacaoProjetoDTO, PropostaSolicitacaoProjeto>();
            CreateMap<PropostaSolicitacaoProjeto, PropostaSolicitacaoProjetoDTO>();
            CreateMap<PerfilUserDTO, PerfilUser>();
        }
    }
}
