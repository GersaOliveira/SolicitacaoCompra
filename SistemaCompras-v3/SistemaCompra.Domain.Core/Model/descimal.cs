using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaCompra.Domain.Core.Model
{
    public class descimal : ValueObject<descimal>
    {
        public readonly decimal Value;

        public descimal()
                : this(0m)
        {
        }

        public descimal(decimal value)
        {
            Value = value;
        }

        public descimal Add(descimal money)
        {
            return new descimal(Value + money.Value);
        }

        public descimal Subtract(descimal money)
        {
            return new descimal(Value - money.Value);
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new List<Object>() { Value };
        }
    }
}
