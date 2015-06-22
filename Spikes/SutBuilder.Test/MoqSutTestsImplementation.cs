using NUnit.Framework;
using SutBuilder.Test.DemoClassess;

namespace SutBuilder.Test
{
    public class MoqSutTestsImplementation : MoqSutTests<DemoClassWithServices>
    {
        [Test]
        public void Test1()
        {
            var sut = CreateSut();
            Given(sut);
        }


    }
}