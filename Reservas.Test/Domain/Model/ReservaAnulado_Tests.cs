using Reservas.Domain.Model.ReservaAnulados;
using System;
using Xunit;

namespace Reservas.Test.Domain.Model
{
    public class ReservaAnulado_Tests
    {
        [Fact]
        public void ReservaAnulado_CheckPropertiesValid()
        {
            var descripcionTest = "reserva no pagada";        
            var reservaIdTest = Guid.NewGuid();

            var obj = new ReservaAnulado(descripcionTest, reservaIdTest);

            Assert.Equal(descripcionTest, obj.Descripcion);
            Assert.Equal(reservaIdTest, obj.ReservaId);
        }

        [Fact]
        public void TestConstructor_IsPrivate()
        {
            var command = (ReservaAnulado)Activator.CreateInstance(typeof(ReservaAnulado), true);
            Assert.Equal(Guid.Empty, command.Id);
        }
    }
}
