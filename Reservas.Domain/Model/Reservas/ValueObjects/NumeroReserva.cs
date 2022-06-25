using ShareKernel.Core;
using ShareKernel.Rules;

namespace Reservas.Domain.Model.Reservas.ValueObjects
{
    public record NumeroReserva: ValueObject
    {
        public string Value { get; }

        public NumeroReserva(string value)
        {
            CheckRule(new StringNotNullOrEmptyRule(value));
            Value = value;
        }


        public static implicit operator string(NumeroReserva value)
        {
            return value.Value;
        }

        public static implicit operator NumeroReserva(string value)
        {
            return new NumeroReserva(value);
        }
    }
}
