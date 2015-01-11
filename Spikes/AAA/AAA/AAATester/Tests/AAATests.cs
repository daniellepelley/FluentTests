using System;
using AAATester.AAA;
using NUnit.Framework;

namespace AAATester.Tests
{
    [TestFixture]
// ReSharper disable once InconsistentNaming
    public partial class AAATests
    {
        [Test]
        public void Test1()
        {
            const string expected = "Completed";

            Test<TestableClass, TestableBuilder>
                .Arrange(b => b.WithStatus("Active"))
                .Act(SetStatusTo(expected))
                .Assert(StatusIs(expected));
        }

        [Test]
        public void Test3()
        {
            Test<TestableClass>
                .Arrange(() => new TestableClass("e"))
                .Act(x => x.StatusIsSetTo("fef"))
                .AssertAreEqual(x => x.Status, "fef");
        }





        //[Test]
        //public void Test2()
        //{
        //    const string expected = "Completed";

        //    TestSet<TestableClass>.New
        //        .Test(
        //            "Set Status changes the status",
        //            testCase =>
        //            {
        //                const string active = "Active";
        //                const string completed = "Completed";
        //                testCase
        //                    .Arrange(() => new TestableClass(active))
        //                    .Act(
        //                        x => x.SetStatus("active"),
        //                        SetStatusTo(active),
        //                        SetStatusTo(completed),
        //                        x =>
        //                        {
        //                            x.SetStatus(active);
        //                            x.SetStatus(completed);
        //                        })
        //                    .Assert(StatusIs(completed));
        //            }
        //        )
        //    .Test("This is a test",
        //        testCase =>
        //        {
        //            const string startStatus = "Active";
        //            testCase
        //                .Arrange(() => new TestableClass(startStatus))
        //                .Act(SetStatusTo("Completed"))
        //                .AssertStatusIs("Completed");
        //        }
        //        );
        //}
    }


    public partial class AAATests
    {
        public Action<TestableClass> SetStatusTo(string value)
        {
            return x => x.StatusIsSetTo(value);
        }

        public Func<TestableClass, bool> StatusIs(string value)
        {
            return x => x.Status == value;
        }   
    }

    public static class TestExtensions
    {
        public static TestAssert<TestableClass> Act_SetToCompleted(this TestAct<TestableClass> source)
        {
            return source.Act(sut => sut.StatusIsSetTo("Completed"));
        }

        public static TestAssert<TestableClass> Act_SetToActive(this TestAct<TestableClass> source)
        {
            return source.Act(sut => sut.StatusIsSetTo("Active"));
        }

        public static TestAssert<TestableClass> AssertStatusIs(this TestAssert<TestableClass> source, string status)
        {
            return source.Assert(x => x.Status == status);
        }
    }
}
