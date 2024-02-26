using MediatR;
using SistemaCompra.Infra.Data.UoW;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SolicitacaoCompraAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;
using ProdutoAgg = SistemaCompra.Domain.ProdutoAggregate;
using SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistraCompraCommandHandler : CommandHandler, IRequestHandler<RegistraCompraCommand, bool>
    {
        private readonly SolicitacaoCompraAgg.ISolicitacaoCompraRepository _solicitacaoCompraRepository;
        private readonly ProdutoAgg.IProdutoRepository _produtoRepository;

        public RegistraCompraCommandHandler(SolicitacaoCompraAgg.ISolicitacaoCompraRepository solicitacaocomprarepository,
            IUnitOfWork uow, IMediator mediator, ProdutoAgg.IProdutoRepository produtoRepository) : base(uow, mediator)
        {
            _solicitacaoCompraRepository = solicitacaocomprarepository;
            _produtoRepository = produtoRepository;
        }

        public Task<bool> Handle(RegistraCompraCommand request, CancellationToken cancellationToken)
        {
            var compra = new SolicitacaoCompraAgg.SolicitacaoCompra(
                request.UsuarioSolicitante, request.NomeFornecedor, request.CondicaoPagamento);

            
            foreach (var item in request.Item)
            {
                var produto = _produtoRepository.Obter(item.Produto.Id);

                compra.AdicionarItem(produto, item.Qtde);
            }



            compra.RegistrarCompra(compra.Itens);
            _solicitacaoCompraRepository.RegistrarCompra(compra);

 

            Commit();
            PublishEvents(compra.Events);

            return Task.FromResult(true);
        }
    }
}
