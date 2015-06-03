using System;
using AAATester.AAA;

namespace AAATester
{
    public static class Test<TSut, TBuilder>
        where TBuilder : IBuilder<TSut>
        where TSut : class
    {
        public static TestAct<TSut, TBuilder> Arrange(Action<TBuilder> action)
        {
            var builder = Activator.CreateInstance<TBuilder>();
            action(builder);
            return new TestAct<TSut, TBuilder>(builder);
        }
    }

    public static class Test<TSut>
    {
        public static TestAct<TSut> Arrange()
        {
            return Arrange(Activator.CreateInstance<TSut>);
        }

        public static TestAct<TSut> Arrange(Func<TSut> func)
        {
            var sut = func(); 
            return new TestAct<TSut>(sut);
        }
    }
}