using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using ProdutoAgg = SistemaCompra.Domain.ProdutoAggregate;
using CompraAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistraCompraCommand : IRequest<bool>
    {
        public string UsuarioSolicitante { get;  set; }
        public string NomeFornecedor { get;  set; }
        public DateTime Data { get;  set; }
        public CompraAgg.SituacaoCompra Situacao { get;  set; }
        public IList<Item> Item { get; set; }
        public int CondicaoPagamento { get; set; }


    }
}
