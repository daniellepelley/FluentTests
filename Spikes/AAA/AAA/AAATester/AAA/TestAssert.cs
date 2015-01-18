using System;

namespace AAATester.AAA
{
    public class TestAssert<TSut, TBuilder>
        where TBuilder : IBuilder<TSut>
        where TSut : class
    {
        private readonly TBuilder _builder;

        private readonly TSut _sut;

        public TestAssert(TBuilder builder, TSut sut)
        {
            _builder = builder;
            _sut = sut;
        }

        public TestAssert<TSut, TBuilder> Assert(Action<TBuilder, TSut> action)
        {
            action(_builder, _sut);
            return this;
        }

        public TestAssert<TSut, TBuilder> Assert(Action<TSut> action)
        {
            action(_sut);
            return this;
        }

        public TestAssert<TSut, TBuilder> Assert(Func<TBuilder, TSut, bool> func)
        {
            NUnit.Framework.Assert.IsTrue(func(_builder, _sut));
            return this;
        }

        public TestAssert<TSut, TBuilder> Assert(Func<TSut, bool> func)
        {
            NUnit.Framework.Assert.IsTrue(func(_sut));
            return this;
        }
    }

    public class TestAssert<TSut>
    {
        private readonly TSut _sut;

        public TestAssert(TSut sut)
        {
            _sut = sut;
        }

        public TestAssert<TSut> Assert(Action<TSut> action)
        {
            action(_sut);
            return this;
        }

        public TestAssert<TSut> Assert(Func<TSut, bool> func)
        {
            NUnit.Framework.Assert.IsTrue(func(_sut));
            return this;
        }

        public TestAssert<TSut> AssertAreEqual<TValue>(Func<TSut, TValue> action, TValue value)
        {
            NUnit.Framework.Assert.AreEqual(value, action(_sut));
            return this;
        }

        public override string ToString()
        {
            return "This tests if the option works";
        }
    }
}
