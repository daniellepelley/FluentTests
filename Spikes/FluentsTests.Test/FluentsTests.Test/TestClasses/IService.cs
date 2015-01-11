namespace FluentsTests.Test.TestClasses
{
    public interface IService
    {
        void Run(string message);
        string GetStatus();
    }
}