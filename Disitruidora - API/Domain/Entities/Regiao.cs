using System.Collections.Generic;
using FluentValidation;

namespace Domain.Entities
{
    public class Regiao : BaseEntity<Regiao>
    {
        public string Nome { get; set; }
        public decimal CoordenadaX { get; set; }
        public decimal CoordenadaY { get; set; }
        public virtual IEnumerable<Armazem> Armazens { get; set; }
        public virtual IEnumerable<Participante> Participantes { get; set; }

        protected override bool EhValido()
        {
            ValidarCoordenadas();
            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }


        public void ValidarCoordenadas()
        {
            RuleFor(x => x.CoordenadaX).Must(x => x > 0).WithMessage("A coordenada x não pode ter valor negativo");
            RuleFor(x => x.CoordenadaY).Must(x => x > 0).WithMessage("A coordenada Y não pode ter valor negativo");
        }
    }
}