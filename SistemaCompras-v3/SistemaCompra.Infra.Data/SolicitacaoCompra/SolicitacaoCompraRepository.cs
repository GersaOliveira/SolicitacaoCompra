using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SolicitacaoAggregate = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Infra.Data.SolicitacaoCompra
{
    public class SolicitacaoCompraRepository : SolicitacaoAggregate.ISolicitacaoCompraRepository
    {
        private readonly SistemaCompraContext context;

        public SolicitacaoCompraRepository(SistemaCompraContext context)
        {
            this.context = context;
        }

        public void RegistrarCompra(SolicitacaoAggregate.SolicitacaoCompra solicitacaoCompra)
        {
            context.Set<SolicitacaoAggregate.SolicitacaoCompra>().Add(solicitacaoCompra);
        }

        public SolicitacaoAggregate.SolicitacaoCompra Obter(Guid id)
        {
            return context.Set<SolicitacaoAggregate.SolicitacaoCompra>().Where(c => c.Id == id).FirstOrDefault();
        }
    }
}
