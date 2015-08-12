using System.Linq;
using System.Reflection;
using SutBuilder.Interfaces;

namespace SutBuilder
{
    public class ClassConstructor : IClassConstructor
    {
        private readonly IDependencyResolver _dependencyResolver;

        public ClassConstructor()
            : this(new ActivatorDependencyResolver())
        { }

        public ClassConstructor(IDependencyResolver dependencyResolver)
        {
            _dependencyResolver = dependencyResolver;
        }

        public T Build<T>(ConstructorInfo constructor)
        {
            var parameters = constructor
                .GetParameters()
                .Select(x => _dependencyResolver.Resolve(x.ParameterType))
                .ToArray();

            return (T)constructor.Invoke(parameters);
        }
    }
}