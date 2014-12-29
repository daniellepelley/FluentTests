namespace FluentTests.Moq
{
    public class MoqSutBuilder<TSut>
        : ISutBuilder<TSut>
    {
        public TSut Build()
        {
            var mocker = new Mocker<TSut>();
            return mocker.Activate();
        }
    }
}