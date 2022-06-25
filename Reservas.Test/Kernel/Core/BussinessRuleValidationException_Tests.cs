using Moq;
using ShareKernel.Core;
using Xunit;

namespace Reservas.Test.Kernel.Core
{
    public class BussinessRuleValidationException_Tests
    {
        private readonly Mock<IBussinessRule> BrokenRule;
        public string Mensaje { get; private set; }

        public BussinessRuleValidationException_Tests()
        {
            BrokenRule = new Mock<IBussinessRule>();
        }
        [Fact]
        public void BussinessRuleValidationException()
        {

            var obj = new BussinessRuleValidationException(BrokenRule.Object);
            var data = new BussinessRuleValidationException(Mensaje);

            var stringTest =obj.ToString();

            Assert.NotNull(stringTest);
        }
    }
}
