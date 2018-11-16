﻿using System;

namespace Domain.Entities
{
    public class Item : BaseEntity<Item>
    {
        public int IdProduto { get; set; }
        public int IdNota { get; set; }
        public int Quantidade { get; set; }
        public Nota Nota { get; set; }
        public Produto Produto { get; set; }

        protected override bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}