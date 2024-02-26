using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.Core.Model;
using produtoAgg = SistemaCompra.Domain.ProdutoAggregate;
using SistemaCompra.Domain.SolicitacaoCompraAggregate.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using SistemaCompra.Domain.ProdutoAggregate.Events;
using SistemaCompra.Domain.ProdutoAggregate;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public class SolicitacaoCompra : Entity
    {
        public string UsuarioSolicitante { get; private set; }
        public string NomeFornecedor { get; private set; }
        public IList<Item> Itens { get; private set; } = new List<Item>();
        public DateTime Data { get; private set; }
        public SituacaoCompra Situacao { get; private set; }
        public int CondicaoPagamento { get; private set; }
        public decimal TotalGeral { get; private set; }

        private SolicitacaoCompra() { }

        public SolicitacaoCompra(string usuarioSolicitante, string fornecedor, int condicaoPagamento)
        {
            Id = Guid.NewGuid();
            UsuarioSolicitante = new Usuario(usuarioSolicitante).Nome;
            NomeFornecedor = new Fornecedor(fornecedor).Nome;
            Data = DateTime.Now;
            Situacao = SituacaoCompra.Solicitado;
            CondicaoPagamento = new CondicaoPagamento(condicaoPagamento).Valor;

        }

        public void AdicionarItem(produtoAgg.Produto produto, int qtde)
        {
            var item = new Item(produto, qtde);

            Itens.Add(item);


        }

        public void RegistrarCompra(IEnumerable<Item> itens)
        {
            var qtd = itens.Sum(x => x.Qtde);
            var preco = itens.Sum(x => x.Produto.Preco);
            TotalGeral = qtd * preco ;

            ValidarItens();
            ValidarTotalGeral();
            AddEvent(new CompraRegistradaEvent(Id, itens, TotalGeral));
        }

        public void ValidarTotalGeral()
        {
            // Regra a: Se o Total Geral for maior que 50000, a condição de pagamento deve ser 30 dias.
            if (TotalGeral > 50000)
            {
                CondicaoPagamento = 30;
            }
        }

        public void ValidarItens()
        {
            // Regra b: O total de itens de compra deve ser maior que 0.
            if (Itens == null || !Itens.Any())
            {
                throw new BusinessRuleException("A solicitação de compra deve conter pelo menos um item.");
            }
        }

    }
}
