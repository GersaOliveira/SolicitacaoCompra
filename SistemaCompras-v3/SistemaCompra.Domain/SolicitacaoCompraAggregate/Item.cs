﻿using SistemaCompra.Domain.Core.Model;
using SistemaCompra.Domain.ProdutoAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public class Item : Entity
    {
        public Produto Produto { get; set; }
        public int Qtde { get; set; }

        public descimal Subtotal => ObterSubtotal();

        public Item(Produto produto, int qtde)
        {
            Produto = produto ?? throw new ArgumentNullException(nameof(produto));
            Qtde = qtde;

        }

        private descimal ObterSubtotal()
        {
            decimal preco = Produto.ObterPreco();
            return new descimal(preco * Qtde);
        }

        private Item() { }

    }
}
