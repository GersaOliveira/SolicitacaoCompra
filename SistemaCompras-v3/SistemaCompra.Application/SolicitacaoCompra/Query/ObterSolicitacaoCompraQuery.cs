using MediatR;
using SistemaCompra.Application.Produto.Query.ObterProduto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompra.Application.SolicitacaoCompra.Query
{
    public class ObterSolicitacaoCompraQuery : IRequest<ObterSolicitacaoCompraQueryViewModel>
    {
        public Guid Id { get; set; }
    }
}
