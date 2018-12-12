using System.Collections.Generic;
using FluentValidation;

namespace Domain.Entities
{
    public class Produto : BaseEntity<Produto>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Custo { get; set; }
        public decimal PrecoVenda { get; set; }
        public virtual ICollection<ProdutoArmazem> ProdutosArmazens { get; set; }
        public virtual ICollection<Item> Items { get; set; }


        public void ValidarValores()
        {
            var template = "O {0} deve ser maior que zero";

            RuleFor(x => x.Custo).GreaterThan(0).WithMessage(string.Format(template, "custo"));
            RuleFor(x => x.PrecoVenda).GreaterThan(0).WithMessage(string.Format(template, "preço de venda"));
        }

        protected override bool EhValido()
        {
            ValidarValores();
            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }
    }
}