using System.Collections.Generic;
using FluentValidation;

namespace Domain.Entities
{
    public class Participante : BaseEntity<Participante>
    {
        public int IdRegiao { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public virtual Regiao Regiao { get; set; }
        public virtual IEnumerable<Nota> Nota { get; set; }


        protected override bool EhValido()
        {
            ValidarParticipante();
            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }


        private void ValidarParticipante()
        {
            var template = "O campo {0} está vazio";
            RuleFor(x => x.Endereco).NotEmpty().WithMessage(string.Format(template, "endereco"));
            RuleFor(x => x.Nome).NotEmpty().WithMessage(string.Format(template, "nome"));
        }
    }
}