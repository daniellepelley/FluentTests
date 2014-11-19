using System;
using NUnit.Framework;

namespace AAATester.Spec
{
    public class SpecThen<TSut>
    {
        private readonly TSut _sut;

        public SpecThen(TSut sut)
        {
            _sut = sut;
        }

        public SpecThen<TSut> And(Action<TSut> action)
        {
            action(_sut);
            return this;
        }

        public SpecThen<TSut> And(Func<TSut, bool> func)
        {
            Assert.IsTrue(func(_sut));
            return this;
        }

        public SpecThenAre<TSut, TValue> AndValues<TValue>(Func<TSut, TValue> action, TValue value)
        {
            return new SpecThenAre<TSut, TValue>(this, action(_sut), value);
        }

        public ThenValue<TSut, TValue> And<TValue>(Func<TSut, TValue> action)
        {
            return new ThenValue<TSut, TValue>(
                new SpecThen<TSut>(_sut),
                action(_sut));
        }

        public override string ToString()
        {
            return "This tests if the option works";
        }
    }

    public class SpecThenAre<TSut, TValue>
    {
        private SpecThen<TSut> _specThen;
        private TValue _value1;
        private TValue _value2;

        public SpecThenAre(SpecThen<TSut> specThen, TValue value1, TValue value2)
        {
            _value2 = value2;
            _value1 = value1;
            _specThen = specThen;
        }

        public SpecThen<TSut> AreEqual()
        {
            Assert.AreEqual(_value1, _value2);
            return _specThen;
        }

    }
}
