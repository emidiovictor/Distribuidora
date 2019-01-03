using System;
using System.Collections.Generic;
using FluentValidation;

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
            NomeValido();
            ValidationResult = Validate(this);
            return ValidationResult.IsValid;

        }


        public void NomeValido()
        {
            RuleFor(x => x.Nome).NotEmpty();
        }
    }
}