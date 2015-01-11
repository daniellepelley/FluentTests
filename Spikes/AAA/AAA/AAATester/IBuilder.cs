namespace AAATester
{
    public interface IBuilder<TSut>
        where TSut : class
    {
        TSut Build();
    }
}