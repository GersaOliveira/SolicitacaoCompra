using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompra.Application.SolicitacaoCompra.Query
{
    public class ObterSolicitacaoCompraQueryViewModel
    {
        public string UsuarioSolicitante { get;  set; }
        public string NomeFornecedor { get;  set; }
        public IList<Item> Itens { get;  set; }
        public DateTime Data { get;  set; }
        public SituacaoCompra Situacao { get;  set; }
        public int CondicaoPagamento { get;  set; }
        public decimal TotalGeral { get;  set; }
    }
}
