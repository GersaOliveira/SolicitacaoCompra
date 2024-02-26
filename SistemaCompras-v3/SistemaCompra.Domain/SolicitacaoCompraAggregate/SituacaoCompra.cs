using System.Runtime.Serialization;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    [DataContract(Name = "SolicitacaoCompraSituacao")]
    public enum SituacaoCompra
    {
        Solicitado = 1,
        Recebido = 2,
        Atendido = 3
    }
}