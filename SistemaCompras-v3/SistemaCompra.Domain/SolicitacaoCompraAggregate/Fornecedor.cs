using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public class Fornecedor : ValueObject<Fornecedor>
    {
        public string Nome { get; private set; }

        private Fornecedor() { }

        public Fornecedor(string nome)
        {
            if (String.IsNullOrWhiteSpace(nome)) throw new ArgumentNullException(nameof(nome));
            if (nome.Length < 10) throw new BusinessRuleException("Nome de fornecedor deve ter pelo menos 10 caracteres.");

            Nome = nome;
        }
        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new List<object>() { Nome };
        }

    }
}
