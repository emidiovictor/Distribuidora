using FluentValidation;

namespace Domain.Entities
{
    public class ProdutoArmazem : BaseEntity<ProdutoArmazem>
    {
        public int IdProduto { get; set; }
        public int IdArmazem { get; set; }

        public int Quantidade { get; set; }
        public virtual Armazem Armazem { get; set; }
        public virtual Produto Produto { get; set; }


        public void ValidarQuantidade()
        {
            RuleFor(x => x.Quantidade).GreaterThan(0).WithMessage("A quantidade deve ser maior que zero");
        }

        public override bool IsValid()
        {
            ValidarQuantidade();
            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }
    }
}