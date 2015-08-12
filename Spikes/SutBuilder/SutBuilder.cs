using SutBuilder.Interfaces;

namespace SutBuilder
{
    public class SutBuilder<T> : ISutBuilder<T> where T : class
    {
        private readonly IConstructorProvider _constructorProvider;
        private readonly IClassConstructor _classConstructor;

        public SutBuilder(IConstructorProvider constructorProvider, IClassConstructor classConstructor)
        {
            _classConstructor = classConstructor;
            _constructorProvider = constructorProvider;
        }

        public T Build()
        {
            var constructorInfo =_constructorProvider.Get<T>();
            return _classConstructor.Build<T>(constructorInfo);
        }
    }

    public class SutBuilder
    {
        public dynamic Build()
        {
            return new {};
        }
    }
}