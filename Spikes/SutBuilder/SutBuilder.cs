namespace SutBuilder
{
    public class SutBuilder<T> : ISutBuilder<T> where T : class
    {
        private readonly IConstructorGetter<T> _constructorGetter;
        private readonly IClassConstructor<T> _classConstructor;

        public SutBuilder(IConstructorGetter<T> constructorGetter, IClassConstructor<T> classConstructor)
        {
            _classConstructor = classConstructor;
            _constructorGetter = constructorGetter;
        }

        public T Build()
        {
            var constructorInfo =_constructorGetter.Get();
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