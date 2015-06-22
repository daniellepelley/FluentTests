using SutBuilder.Interfaces;

namespace SutBuilder
{
    public class SutBuilder<T> : ISutBuilder<T> where T : class
    {
        private readonly IConstructorProvider<T> _constructorProvider;
        private readonly IClassConstructor<T> _classConstructor;

        public SutBuilder(IConstructorProvider<T> constructorProvider, IClassConstructor<T> classConstructor)
        {
            _classConstructor = classConstructor;
            _constructorProvider = constructorProvider;
        }

        public T Build()
        {
            var constructorInfo =_constructorProvider.Get();
            return _classConstructor.Build(constructorInfo);
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