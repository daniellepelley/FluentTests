using System;
using System.Linq;
using System.Reflection;

namespace SutBuilder
{
    public class ClassConstructor<T> : IClassConstructor<T>
    {
        public T Build(ConstructorInfo constructor)
        {
            var parameters = constructor
                .GetParameters()
                .Select(x => Activator.CreateInstance(x.ParameterType))
                .ToArray();

            return (T)constructor.Invoke(parameters);
        }
    }
}