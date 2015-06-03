using NUnit.Framework;
using SutBuilder.Test.DemoClassess;

namespace SutBuilder.Test
{
    public class SutTestsImplementation : SutTests<DemoClassWithServices>
    {
        [Test]
        public void Test1()
        {
            var sut = CreateSut();
            
        }
    }
}