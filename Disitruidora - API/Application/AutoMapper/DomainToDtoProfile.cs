using Application.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.AutoMapper
{
    public class DomainToDtoProfile : Profile
    {

        public DomainToDtoProfile()
        {
            CreateMap<ArmazemCadastroDto, Armazem>();
        }
        
    }
}