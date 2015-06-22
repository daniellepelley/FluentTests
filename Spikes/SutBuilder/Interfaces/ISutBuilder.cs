namespace SutBuilder.Interfaces
{
    public interface ISutBuilder<T>
        where T : class
    {
        T Build();
    }
}