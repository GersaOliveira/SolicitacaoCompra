using SistemaCompra.Domain.Core;
using SistemaCompra.Domain.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompra.Domain.SolicitacaoCompraAggregate
{
    public class Usuario : ValueObject<Usuario>
    {
        public string Nome { get; }

        private Usuario() { }

        public Usuario(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentNullException(nameof(nome));
            if (nome.Length < 5) throw new BusinessRuleException("Nome de usuário deve possuir pelo menos 8 caracteres.");
            
            Nome = nome;
        }
        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new List<object>() { Nome };
        }
    }
}
