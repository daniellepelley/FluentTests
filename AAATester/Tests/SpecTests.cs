using System;
using System.Linq.Expressions;
using AAATester.Spec;
using NUnit.Framework;

namespace AAATester.Tests
{
    [TestFixture]
    public partial class SpecTests
    {
        [Test]
        public void Test1()
        {
            GivenAnActiveStatus()
                .WhenStatusIsSetTo("Completed")
                .ThenValues(x => x.Status, "Completed").AreEqual();
        }

        [Test]
        public void Test2()
        {
            SetStatusMethod()
                .WithParameters("Completed")
                .Returns("Completed");

            SetStatusMethod()
                .WithParameters("Active")
                .Returns("Active");

            GivenAnActiveStatus()
                .When(StatusIs("Completed"))
                .Then(x => x.Status)
                    .IsEqualTo("Completed")
                .And(x => x.Status)
                    .IsNotEqualTo("Active");
        }
    }















    public partial class SpecTests
    {
        public static SpecWhen<TestableClass> GivenAnActiveStatus()
        {
            return Spec<TestableClass>
                .Given(() => new TestableClass("Active"));
        }

        public Action<TestableClass> StatusIs(string status)
        {
            return x => x.SetStatus(status);
        }

        public static SpecMethod<TestableClass> SetStatusMethod()
        {
            return GivenAnActiveStatus()
                .Method<TestableClass, Expression<Func<string, string>>>(x => s => x.SetStatus(s));
        }
    }

    public static class SpecExtensions
    {
        public static SpecWhenAnd<TestableClass> WhenStatusIsSetTo(this SpecWhen<TestableClass> source, string status)
        {
            return source.When(x => x.SetStatus("Completed"));
        }
    }

}
