using Reservas.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Domain.ValueObject
{
    public record CantidadValue_Tests
    {
        [Fact]
        public void CantidadValue_CheckPropertiesValid()
        {
            var value = 100;
            var importePagadoTest = new CantidadValue(value);
            Assert.Equal(100, Convert.ToInt32(importePagadoTest));

        }

    }
}
