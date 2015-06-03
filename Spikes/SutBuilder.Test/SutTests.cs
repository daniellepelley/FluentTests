using SutBuilder.Moq;

namespace SutBuilder.Test
{
    public class SutTests<T>
        where T : class
    {
        private readonly ConstructorGetter<T> _constructorGetter;
        private readonly MoqClassConstructor<T> _moqClassConstructor;

        public SutTests()
        {
            _constructorGetter = new ConstructorGetter<T>();
            _moqClassConstructor = new MoqClassConstructor<T>();
        }

        public SutBuilder<T> CreateSutBuilder()
        {
            return new SutBuilder<T>(_constructorGetter, _moqClassConstructor); 
        }

        public T CreateSut()
        {
            return CreateSutBuilder().Build();
        }
    }
}