using FluentValidation;

namespace Domain.Entities
{
    public class ProdutoArmazem : BaseEntity<ProdutoArmazem>
    {
        public int IdProduto { get; set; }
        public int IdArmazem { get; set; }

        public int Quantidade { get; set; }
        public Armazem Armazem { get; set; }
        public Produto Produto { get; set; }


        public void ValidarQuantidade()
        {
            RuleFor(x => x.Quantidade).GreaterThan(0).WithMessage("A quantidade deve ser maior que zero");
        }

        protected override bool EhValido()
        {
            ValidarQuantidade();
            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }
    }
}