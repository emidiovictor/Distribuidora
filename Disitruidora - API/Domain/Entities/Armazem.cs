using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Armazem : BaseEntity<Armazem>
    {
        public string Nome { get; set; }
        public int IdRegiao { get; set; }
        public virtual Regiao Regiao { get; set; }
        public virtual ICollection<ProdutoArmazem> ProdutoArmazem { get; set; }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}