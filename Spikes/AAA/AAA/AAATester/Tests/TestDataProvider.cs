using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace AAATester.Tests
{
    public class TestDataProvider : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Given I have a test, ");
            sb.AppendLine("When I run the test, ");
            sb.AppendLine("Then the result is this");

            return new List<TestCaseData>
            {
                new TestCaseData(
                    Test<TestableClass>
                        .Arrange(() => new TestableClass("e"))
                        .Act(x => x.StatusIsSetTo("fef"))
                        .AssertAreEqual(x => x.Status, "fef"))
                    .SetName(sb.ToString())
                    .SetDescription(sb.ToString())
                    .SetCategory("TestableClass Else"),

                new TestCaseData(
                    Test<TestableClass>
                        .Arrange(() => new TestableClass("e"))
                        .Act(x => x.StatusIsSetTo("fef"))
                        .AssertAreEqual(x => x.Status, "fef"))
                    .SetName(sb.ToString())
                    .SetDescription(sb.ToString())
                    .SetCategory("TestableClass")


            }.GetEnumerator();
        }
    }
}