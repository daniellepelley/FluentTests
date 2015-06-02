using NUnit.Framework;

namespace Assertions.Core.NUnit
{
    public class NUnitAssertionService : IAssertionService
    {
        public void AreEqual<T>(T source, T value)
        {
            Assert.AreEqual(source, value);
        }

        public void AreEqual<T>(T source, T value, string message)
        {
            Assert.AreEqual(source, value, message);
        }

        public void AreNotEqual<T>(T source, T value)
        {
            Assert.AreNotEqual(source, value);
        }

        public void AreNotEqual<T>(T source, T value, string message)
        {
            Assert.AreNotEqual(source, value, message);
        }
    }
}
