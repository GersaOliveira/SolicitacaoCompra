using System.Runtime.Serialization;

namespace SistemaCompra.Domain.ProdutoAggregate
{
    [DataContract(Name = "ProdutoSituacao")]
    public enum Situacao
    {
        Ativo = 1,
        Suspenso = 2
    }
}
