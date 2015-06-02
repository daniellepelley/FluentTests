using System.IO;
using System.Reflection;
using Assertions.Core;
using Assertions.Core.NUnit;
using NUnit.Framework;

namespace Assertions.Test
{
    public class IsEqualToTests
    {
        public IsEqualToTests()
        {
            AssertionExtensions.AssertionService = new NUnitAssertionService();
        }

        [Test]
        public void IsEqualTo()
        {
            "This".IsEqualTo("This");
        }

        [Test]
        public void IsEqualToWithMessage()
        {
            "This".IsEqualTo("This", "Passed");
        }

        [Test]
        public void IsNotEqualTo()
        {
            "This".IsNotEqualTo("That");
        }

        [Test]
        public void IsNotEqualToWithMessage()
        {
            "This".IsNotEqualTo("That", "Failed");
        }

    }
}
