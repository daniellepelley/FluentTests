using SutBuilder.Interfaces;

namespace SutBuilder
{
    public static class Sut
    {
        private static IClassConstructor _classConstructor;

        static Sut()
        {
            _classConstructor = new ClassConstructor();
        }

        public static T Create<T>()
            where T : class
        {
            var sutBuilder = new SutBuilder<T>(new ConstructorProvider(), _classConstructor);
            return sutBuilder.Build();
        }

        public static void SetClassConstructor(IClassConstructor classConstructor)
        {
            _classConstructor = classConstructor;
        }
    }
}
