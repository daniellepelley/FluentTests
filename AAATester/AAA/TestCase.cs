using System;
using AAATester.AAA;

namespace AAATester
{
    public class TestCase<TSut>
    {
        private string _description;

        public TestCase(string description)
        {
            _description = description;
        }

        public TestAct<TSut> Arrange()
        {
            return Arrange(Activator.CreateInstance<TSut>);
        }

        public TestAct<TSut> Arrange(Func<TSut> func)
        {
            var sut = func();
            return new TestAct<TSut>(sut);
        }
    }
}