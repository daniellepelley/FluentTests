namespace SutBuilder
{
    public interface IFactory<T>
    {
        T Create();
    }
}