using NUnit.Framework;

namespace Assertions.Core.NUnit
{
    public class NUnitAssertionService : IAssertionService
    {
        public void AreEqual<T>(T source, T value)
        {
            Assert.AreEqual(source, value);
        }
    }
}
