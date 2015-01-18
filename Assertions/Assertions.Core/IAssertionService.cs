namespace Assertions.Core
{
    public interface IAssertionService
    {
        void AreEqual<T>(T source, T value);
    }
}