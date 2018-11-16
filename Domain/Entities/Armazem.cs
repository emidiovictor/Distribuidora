using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Armazem : BaseEntity<Armazem>
    {
        public string Nome { get; set; }
        public int IdRegiao { get; set; }
        public Regiao Regiao { get; set; }
        public ICollection<ProdutoArmazem> ProdutoArmazem { get; set; }

        protected override bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}