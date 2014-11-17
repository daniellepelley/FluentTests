using System;

namespace AAATester.AAA
{
    public class TestSet<TSut>
    {
        public static TestSet<TSut> New
        {
            get { return new TestSet<TSut>(); }
        }

        public TestSet<TSut> Test(string description, Action<TestCase<TSut>> action)
        {
            var testCase = new TestCase<TSut>(description);
            action(testCase);
            return this;
        }
    }
}