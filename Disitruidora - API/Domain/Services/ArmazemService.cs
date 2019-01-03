using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class ArmazemService : IArmazemService
    {
        private readonly IArmazemRepository _armazemRepository;

        public ArmazemService(IArmazemRepository armazemRepository)
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

        public Armazem CadastrarArmazem(Armazem arm)
        {
            if (!arm.IsValid()) return null;
            _armazemRepository.Add(arm);
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