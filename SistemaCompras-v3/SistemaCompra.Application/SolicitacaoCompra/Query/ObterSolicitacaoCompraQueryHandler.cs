using System;
using System.Collections.Generic;
using System.Text;

using ProdutoAgg = SistemaCompra.Domain.ProdutoAggregate;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;
using MediatR;
using AutoMapper;
using SistemaCompra.Domain.ProdutoAggregate;
using System.Threading;
using System.Threading.Tasks;

namespace SistemaCompra.Application.SolicitacaoCompra.Query
{
 
    public class ObterSolicitacaoCompraQueryHandler : IRequestHandler<ObterSolicitacaoCompraQuery, ObterSolicitacaoCompraQueryViewModel>
    {
        private readonly ISolicitacaoCompraRepository _solicitacaoCompraRepository;
        private readonly IMapper _mapper;

        public ObterSolicitacaoCompraQueryHandler(ISolicitacaoCompraRepository solicitacaoCompraRepository, IMapper mapper)
        {
            _solicitacaoCompraRepository = solicitacaoCompraRepository;
            _mapper = mapper;
        }
        public Task<ObterSolicitacaoCompraQueryViewModel> Handle(ObterSolicitacaoCompraQuery request, CancellationToken cancellationToken)
        {
            var compra = _solicitacaoCompraRepository.Obter(request.Id);
            var compraViewModel = _mapper.Map<ObterSolicitacaoCompraQueryViewModel>(compra);

            return Task.FromResult(compraViewModel);
        }
    }
}
