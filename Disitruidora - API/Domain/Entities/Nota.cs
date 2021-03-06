﻿using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;

namespace Domain.Entities
{
    public class Nota : BaseEntity<Nota>
    {
        public int IdUsuario { get; set; }
        public int IdParticipante { get; set; }
        public DateTime DataOperacao { get; set; }
        public int TipoNota { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual Participante Participante { get; set; }

        public virtual List<Item> ListaItem { get; set; }

        public double CalculaValorTotalCompra()
        {
            return ListaItem.Sum(i => (double) (i.Quantidade * i.Produto.Custo));
        }

        public double CalculaValorTotalVenda()
        {
            return ListaItem.Sum(i => (double) (i.Quantidade * i.Produto.PrecoVenda));
        }


        public override bool IsValid()
        {
            ValidarTipNota();
            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }

        private void ValidarTipNota()
        {
            RuleFor(x => x.TipoNota).InclusiveBetween(1, 2)
                .WithMessage("Os valores aceitos são: 1 - Entrada, 2 - Saída");
        }
    }
}