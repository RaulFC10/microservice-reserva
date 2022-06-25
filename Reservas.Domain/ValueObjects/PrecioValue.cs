using ShareKernel.Core;

namespace Reservas.Domain.ValueObjects
{
    public record PrecioValue
    {
        public decimal Value { get; }
        public PrecioValue(decimal value)
        {
            if (value < 0)
            {
                throw new BussinessRuleValidationException("El valor no puede ser negativo");
            }
            Value = value;
        }

        public static implicit operator decimal(PrecioValue value)
        {
            return value.Value;
        }

        public static implicit operator PrecioValue(decimal value)
        {
            return new PrecioValue(value);
        }
    }
}
