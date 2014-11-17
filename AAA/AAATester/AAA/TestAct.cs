using System;

namespace AAATester.AAA
{
    public class TestAct<TSut, TBuilder>
        where TBuilder : IBuilder<TSut>
    {
        private readonly TBuilder _builder;

        private readonly TSut _sut;

        public TestAct(TBuilder builder)
        {
            _builder = builder;
            _sut = builder.Build();
        }

        public TestAssert<TSut, TBuilder> Act(Action<TBuilder, TSut> action)
        {
            action(_builder, _sut);
            return new TestAssert<TSut, TBuilder>(_builder, _sut);
        }

        public TestAssert<TSut, TBuilder> Act(Action<TSut> action)
        {
            action(_sut);
            return new TestAssert<TSut, TBuilder>(_builder, _sut);
        }

        public TestAssert<TSut, TBuilder> Act()
        {
            return new TestAssert<TSut, TBuilder>(_builder, _sut);
        }
    }

    public class TestAct<TSut>
    {
        private readonly TSut _sut;

        public TestAct(TSut sut)
        {
            _sut = sut;
        }

        public TestAssert<TSut> Act(params Action<TSut>[] actions)
        {
            foreach (var action in actions)
            {
                action(_sut);
            }
            return new TestAssert<TSut>(_sut);
        }

        public TestAssert<TSut> Act()
        {
            return new TestAssert<TSut>(_sut);
        }
    }
}