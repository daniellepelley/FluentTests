using SutBuilder.Interfaces;

namespace SutBuilder
{
    public class SutTests<T>
        where T : class
    {
        private readonly IClassConstructor<T> _classConstructor;
        private readonly IConstructorProvider<T> _constructorProvider;

        public SutTests(IClassConstructor<T> classConstructor, IConstructorProvider<T> constructorProvider)
        {
            _constructorProvider = constructorProvider;
            _classConstructor = classConstructor;
        }

        public SutBuilder<T> CreateSutBuilder()
        {
            return new SutBuilder<T>(_constructorProvider, _classConstructor); 
        }

        public T CreateSut()
        {
            return CreateSutBuilder().Build();
        }
    }
}