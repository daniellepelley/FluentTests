using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using Stubber.Tests.TestClasses;

namespace Stubber
{
    public class Mocker<T>
    {
        private Dictionary<Type, object> _mocks;

        public Mocker()
        {
            _mocks = new Dictionary<Type, object>();
        }

        public T Activate(params object[] mocks)
        {
            _mocks = new Dictionary<Type, object>();

            var constructor = typeof(T)
                .GetConstructors()
                .OrderBy(x => x.GetParameters().Length)
                .ToArray()
                .FirstOrDefault();

            foreach (var parameter in constructor.GetParameters())
            {
                var mock = CreateMock(parameter.ParameterType, mocks);
                _mocks.Add(parameter.ParameterType, mock);
            }

            var parameters = _mocks.Select(p => MockToObject(p.Key, p.Value));

            return (T) constructor.Invoke(parameters.ToArray());
        }

        public Mock<TMock> GetMock<TMock>()
            where TMock : class
        {
            return (Mock<TMock>)_mocks[typeof(TMock)];
        }

        private static object CreateMock(Type type, object[] mocks)
        {
            foreach (var mock in mocks)
            {
                if (type.IsInstanceOfType(mock))
                {
                    return mock;
                }
            }
            return DynamicMock(type);
        }

        public static object DynamicMock(Type type)
        {
            var mock = typeof (Mock<>).MakeGenericType(type).GetConstructor(Type.EmptyTypes).Invoke(new object[] {});
            return mock;
        }

        public static object MockToObject(Type type, object mock)
        {
            if (mock is Mock)
            {
                return mock.GetType().GetProperty("Object", type).GetValue(mock, new object[] {});
            }

            return mock;
        }
    }
}
