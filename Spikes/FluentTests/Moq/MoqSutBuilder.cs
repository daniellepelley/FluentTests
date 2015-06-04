using SutBuilder;

namespace FluentTests.Moq
{
    public class MoqSutBuilder<TSut>
        : ISutBuilder<TSut>
        where TSut : class
    {
        public TSut Build()
        {
            var mocker = new Mocker<TSut>();
            return mocker.Activate();
        }
    }
}