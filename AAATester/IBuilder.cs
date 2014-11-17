namespace AAATester
{
    public interface IBuilder<out TSut>
    {
        TSut Build();
    }
}