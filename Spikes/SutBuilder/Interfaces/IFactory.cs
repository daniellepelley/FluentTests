namespace SutBuilder.Interfaces
{
    public interface IFactory<T>
    {
        T Create();
    }
}