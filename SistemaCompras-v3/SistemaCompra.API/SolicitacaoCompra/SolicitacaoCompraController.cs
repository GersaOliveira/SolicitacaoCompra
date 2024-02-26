using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra;
using SistemaCompra.Application.SolicitacaoCompra.Query;

//using SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra;
//using SistemaCompra.Application.SolicitacaoCompra.Query.ObterProduto;
using System;

namespace SistemaCompra.API.SolicitacaoCompra
{
    [Route("api/solicitacoes-compra")]
    [ApiController]
    public class SolicitacaoCompraController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SolicitacaoCompraController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet, Route("SolicitacaoCompra/{id}")]
        public IActionResult Obter(Guid id)
        {
            var query = new ObterSolicitacaoCompraQuery { Id = id };
            var produtoViewModel = _mediator.Send(query);
            return Ok(produtoViewModel);
        }

        [HttpPost, Route("Compra")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult SolicitacaoCompra([FromBody] RegistraCompraCommand registraCompraCommand)
        {
            _mediator.Send(registraCompraCommand);
            return StatusCode(201);
        }

        ////[HttpPut, Route("SolicitacaoCompra/atualiza")]
        ////[ProducesResponseType(200)]
        ////[ProducesResponseType(400)]
        ////[ProducesResponseType(404)]
        ////[ProducesResponseType(500)]
        ////public IActionResult AtualizarPreco([FromBody] AtualizarCompraCommand atualizarPrecoCommand)
        ////{
        ////    _mediator.Send(atualizarPrecoCommand);
        ////    return Ok();

        ////}

    }
}
