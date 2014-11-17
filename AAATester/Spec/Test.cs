using System;
using AAATester.Spec;

namespace AAATester
{
    public class SpecTestSet<TSut>
    {
        public static SpecTestSet<TSut> New
        {
            get { return new SpecTestSet<TSut>(); }
        }

        public SpecTestSet<TSut> Test(string description, Action<TestCase<TSut>> action)
        {
            var testCase = new TestCase<TSut>(description);
            action(testCase);
            return this;
        }
    }
    
    public static class Spec<TSut>
    {
        public static SpecWhen<TSut> Given()
        {
            return Given(Activator.CreateInstance<TSut>);
        }

        public static SpecWhen<TSut> Given(Func<TSut> func)
        {
            var sut = func();
            return new SpecWhen<TSut>(sut);
        }

    }
}