namespace FluentTests
{
    public interface ISutBuilder<TSut>
    {
        TSut Build();
    }
}