using AAATester.AAA;
using NUnit.Framework;

namespace AAATester.Tests
{
    [TestFixture]
    public class MyTests
    {
        [TestCaseSource(typeof(TestDataProvider))]
        public void Test(TestAssert<TestableClass> test)
        {
            Assert.Pass("Test passed");
            Assert.IsFalse(false);
        }
    }
}