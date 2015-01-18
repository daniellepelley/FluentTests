using System;
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
            Console.WriteLine(TestContext.CurrentContext.Test.Properties["_DESCRIPTION"]);

            Assert.Pass("Test passed");
            Assert.IsFalse(false);
        }
    }
}