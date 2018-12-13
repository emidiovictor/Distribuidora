using Application.Dtos;
using AutoMapper;
using AutoMapper.Configuration;
using Domain.Entities;

namespace Application.AutoMapper
{
    public class DtoToDomainProfile : Profile
    {
        public DtoToDomainProfile()
        {
            CreateMap<Armazem, ArmazemConsultaDto>()
                .ForMember(x => x.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.Id))
                .AfterMap((armazem, dto) =>
                {
                    dto.CoordenadaX = armazem.Regiao.CoordenadaX;
                    dto.DescricaoRegiao = armazem.Regiao.Nome;
                    dto.CoordenadaY= armazem.Regiao.CoordenadaY;
                    
                });



        }
        
    }
}