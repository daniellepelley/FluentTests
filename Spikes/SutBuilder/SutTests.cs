using SutBuilder.Interfaces;

namespace SutBuilder
{
    public class SutTests<T>
        where T : class
    {
        private readonly IClassConstructor _classConstructor;
        private readonly IConstructorProvider _constructorProvider;

        public SutTests(IClassConstructor classConstructor, IConstructorProvider constructorProvider)
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