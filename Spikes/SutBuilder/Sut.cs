namespace SutBuilder
{
    public static class Sut<T>
        where T : class
    {
        public static readonly SutBuilder<T> SutBuilder;

        static Sut()
        {
            SutBuilder = new SutBuilder<T>(new ConstructorProvider<T>(), new ClassConstructor<T>());
        }

        public static T Create()
        {
            return SutBuilder.Build();
        }
    }
}
