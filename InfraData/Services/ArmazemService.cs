using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using FluentValidation.Results;

namespace InfraData.Services
{
    public class ArmazemService : IArmazemService
    {
        private readonly IArmazemRepository _armazemRepository;

        public ArmazemService(IArmazemRepository armazemRepository)
        {
            _armazemRepository = armazemRepository;
        }

        public List<Armazem> BuscarTodos()
        {
            return _armazemRepository.All().ToList();
        }

        public Armazem BuscarArmazem(int id)
        {
            return _armazemRepository.GetById(id);
        }

        public void CadastrarArmazem(Armazem arm)
        {
            _armazemRepository.Add(arm);
        }

        public void DeletarArmzem(int id)
        {
            var arm = BuscarArmazem(id);
            _armazemRepository.Delete(arm);
        }
    }
}