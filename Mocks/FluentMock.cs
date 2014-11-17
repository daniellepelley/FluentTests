using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace Stubber
{
    public class FluentMock<T>
    {
        private readonly Mocker<T> _mocker;
        private readonly T _sut;

        public FluentMock()
        {
            _mocker = new Mocker<T>();
            _sut = _mocker.Activate();
        }

        public static FluentMock<T> Activate()
        {
            return new FluentMock<T>();
        }

        public static FluentMock<T> When(Action<T> action)
        {
            var fluentStubber = new FluentMock<T>();
            return fluentStubber.Test(action);
        }

        private FluentMock<T> Test(Action<T> action)
        {
            action(_sut);
            return this;
        }

        public FluentMock<T> Then<TMock>(Action<Mock<TMock>> action)
            where TMock : class
        {
            action(_mocker.GetMock<TMock>());
            return this;
        }

        public FluentMock<T> Verify<TMock>(Expression<Action<TMock>> expression, Times times)
            where TMock : class
        {
            _mocker.GetMock<TMock>().Verify(expression, times);
            return this;
        }

        public FluentMock<T> Verify<TMock>(Expression<Action<TMock>> expression, Func<Times> times)
            where TMock : class
        {
            _mocker.GetMock<TMock>().Verify(expression, times);
            return this;
        }

        public FluentMock<T> Verify<TMock>(Expression<Func<TMock, T, bool>> expression)
            where TMock : class
        {
            Assert.IsTrue(expression.Compile()(_mocker.GetMock<TMock>().Object, _sut));
            return this;
        }
    }
}
