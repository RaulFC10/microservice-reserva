using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Domain.ValueObjects
{
    public record CantidadValue
    {
        public int Value { get; }
        public CantidadValue(int value)
        {
            if (value <= 0)
            {
                throw new BussinessRuleValidationException("El valor no puede ser negativo");
            }
            Value = value;
        }

        public static implicit operator int(CantidadValue value)
        {
            return value.Value;
        }

        public static implicit operator CantidadValue(decimal value)
        {
            return new CantidadValue(value);
        }
    }
}
