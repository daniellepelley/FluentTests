using System;
using System.Collections.Generic;
using System.Linq;
using Moq;

namespace FluentTests.Moq
{
    public class Mocker
    {
        public static object DynamicMock(Type type)
        {
            var constructorInfo = typeof(Mock<>).MakeGenericType(type).GetConstructor(Type.EmptyTypes);
            if (constructorInfo != null)
            {
                var mock = constructorInfo.Invoke(new object[] { });
                return mock;
            }
            return null;
        }

        public static object MockToObject(Type type, object mock)
        {
            if (mock is Mock)
            {
                return mock.GetType().GetProperty("Object", type).GetValue(mock, new object[] { });
            }

            return mock;
        }
    }

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

            if (constructor != null)
            {
                foreach (var parameter in constructor.GetParameters())
                {
                    var mock = CreateMock(parameter.ParameterType, mocks);
                    _mocks.Add(parameter.ParameterType, mock);
                }

                var parameters = _mocks.Select(p => Mocker.MockToObject(p.Key, p.Value));

                return (T)constructor.Invoke(parameters.ToArray());
            }
            return default(T);
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
            return Mocker.DynamicMock(type);
        }
    }
}