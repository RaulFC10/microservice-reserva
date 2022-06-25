using ShareKernel.Rules;
using Xunit;

namespace Reservas.Test.Kernel.Rules
{
    public class NotNullRule_Tests
    {
        private object _value;
        [Fact]
        public void NotNullRules()
        {
            var obj = new NotNullRule(_value);
            bool resp = obj.IsValid();
     


        }
    }
}
