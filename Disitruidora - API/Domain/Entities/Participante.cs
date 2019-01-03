using System.Collections.Generic;
using FluentValidation;

namespace Domain.Entities
{
    public class Participante : BaseEntity<Participante>
    {
        public int IdRegiao { get; set; }
        public string Nome { get; set; }
        public int IdEndereco { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual Regiao Regiao { get; set; }
        public virtual IEnumerable<Nota> Nota { get; set; }


        public override bool IsValid()
        {
            ValidarParticipante();
            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }


        private void ValidarParticipante()
        {
            const string template = "O campo {0} está vazio";
            RuleFor(x => x.Nome).NotEmpty().WithMessage(string.Format(template, "nome"));
        }
    }
}