using System;
using Xunit;

namespace Reservas.Test.Kernel.Core
{
    public record  DomainEvent_Tests
    {
        public DateTime OccuredOn { get; }

        [Fact]
        public void DamainEvent()
        {
            Assert.Equal(DateTime.Parse("0001-01-01T00:00:00.0000000"), OccuredOn);
          
        }
    }
}
