using System.Collections.Generic;
using FluentValidation;

namespace Domain.Entities
{
    public class Usuario : BaseEntity<Usuario>
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public virtual IEnumerable<Nota> Notas { get; set; }

        private void ValidarUsuario()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("O campo nome não está preenchido");
            RuleFor(x => x.Login).NotEmpty().WithMessage("O campo login não está preenchido");
            RuleFor(x => x.Login).MaximumLength(10).WithMessage("O login deve ter menos que 10 letras");
        }

        public override bool IsValid()
        {
            ValidarUsuario();
            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
    }
}