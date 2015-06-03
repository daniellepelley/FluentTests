using System;
using System.Linq;
using System.Reflection;
using Moq;

namespace SutBuilder.Moq
{
    public class MoqClassConstructor<T> : IClassConstructor<T>
    {
        public T Build(ConstructorInfo constructor)
        {
            var parameters = constructor
                .GetParameters()
                .Select(x => MockToObject(x.ParameterType, CreateMock(x.ParameterType)))
                .ToArray();

            return (T) constructor.Invoke(parameters);
        }

        private object CreateMock(Type type)
        {
            var mock = 
                typeof(Mock<>).MakeGenericType(type)
                    .GetConstructor(Type.EmptyTypes)
                    .Invoke(new object[] { });
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