using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Services;
using UoW.UoW;

namespace Application.AppService.Base
{
    public class ParticipanteAppService : BaseAppService, IParticipanteAppService
    {

        private readonly IParticipanteService _participanteService;


        public ParticipanteAppService(IMapper mapper, IUnitOfWork uoW, IParticipanteService participanteService) : base(mapper, uoW)
        {
            _participanteService = participanteService;
        }


        public void SalvarParticipante(ParticipanteCadastrarDto dto)
        {
            var participante = Mapper.Map<Participante>(dto);


        }
    }

    public class ParticipanteCadastrarDto
    {
    }
}