using System.Linq;
using System.Reflection;

namespace SutBuilder
{
    public class ClassConstructor<T> : IClassConstructor<T>
    {
        private readonly IDependencyResolver _dependencyResolver;

        public ClassConstructor()
            : this(new ActivatorDependencyResolver())
        { }

        public ClassConstructor(IDependencyResolver dependencyResolver)
        {
            _dependencyResolver = dependencyResolver;
        }

        public T Build(ConstructorInfo constructor)
        {
            var parameters = constructor
                .GetParameters()
                .Select(x => _dependencyResolver.Resolve(x.ParameterType))
                .ToArray();

            return (T)constructor.Invoke(parameters);
        }
    }
}