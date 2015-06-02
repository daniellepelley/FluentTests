namespace Assertions.Core
{
    public interface IAssertionService
    {
        void AreEqual<T>(T source, T value);
        void AreEqual<T>(T source, T value, string message);
        void AreNotEqual<T>(T source, T value);
        void AreNotEqual<T>(T source, T value, string message);
    }
}