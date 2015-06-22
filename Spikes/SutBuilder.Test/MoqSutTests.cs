using FluentTests.Core;
using SutBuilder.Moq;

namespace SutBuilder.Test
{
    public class MoqSutTests<T> : SutTests<T>
        where T : class
    {
        public MoqSutTests()
            :base(new MoqClassConstructor<T>(), new ConstructorProvider<T>())
        { }

        public IGiven<T> Given(T sut)
        {
            return new Given<T>();
        }
    }
}