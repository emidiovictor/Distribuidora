using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Interfaces.Services.Base;

namespace Domain.Services
{
    public class ArmazemService : BaseService, IArmazemService
    {
        private readonly IArmazemRepository _armazemRepository;

        public ArmazemService(INotificationHandler notificationHandler, IArmazemRepository armazemRepository) : base(notificationHandler)
        {
            _armazemRepository = armazemRepository;
        }

        public async Task<IEnumerable<Armazem>> BuscarTodos()
        {
            return await _armazemRepository.All();
        }

        public async Task<Armazem> BuscarArmazem(int id)
        {
            return await _armazemRepository.GetById(id);
        }

        public async Task<Armazem> CadastrarArmazem(Armazem arm)
        {
            if (!arm.IsValid())
            {
                NotificarValidacoesErro(arm.ValidationResult);
                return arm;
            }
            await _armazemRepository.Add(arm);
            return arm;
        }

        public async Task DeletarArmzem(int id)
        {
            var arm = await BuscarArmazem(id);
            _armazemRepository.Delete(arm);
        }

        public async Task<IEnumerable<Armazem>> BuscarArmazemComRegioes()
        {
            return await _armazemRepository.BuscarArmazemERegioes();
        }

        public Armazem Editar(Armazem arm)
        {
            if (!arm.IsValid()) return null;
            _armazemRepository.Update(arm);
            return arm;
        }
    }


}