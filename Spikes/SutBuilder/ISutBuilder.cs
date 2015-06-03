namespace SutBuilder
{
    public interface ISutBuilder<T>
        where T : class
    {
        T Build();
    }
}