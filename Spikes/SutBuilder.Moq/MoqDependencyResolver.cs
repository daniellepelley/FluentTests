using System;
using Moq;
using SutBuilder.Interfaces;

namespace SutBuilder.Moq
{
    public class MoqDependencyResolver : IDependencyResolver
    {
        public object Resolve(Type type)
        {
            return MockToObject(type, CreateMock(type));
        }

        private static object CreateMock(Type type)
        {
            var constructorInfo = typeof(Mock<>).MakeGenericType(type)
                .GetConstructor(Type.EmptyTypes);

            var mock =
                // ReSharper disable once PossibleNullReferenceException
                constructorInfo
                    .Invoke(new object[] { });
            return mock;
        }

        private static object MockToObject(Type type, object mock)
        {
            if (mock is Mock)
            {
                return mock.GetType().GetProperty("Object", type).GetValue(mock, new object[] { });
            }
            return mock;
        }
    }
}