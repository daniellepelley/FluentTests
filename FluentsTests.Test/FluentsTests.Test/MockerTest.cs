using System;
using FluentsTests.Test.TestClasses;
using FluentTests;
using FluentTests.Moq;
using Moq;
using NUnit.Framework;

namespace FluentsTests.Test
{
    public class MockerTests
    {
        [Test]
        public void Activate()
        {
            var sut = new Mocker<ParameterlessConstructorClass>();
            var result = sut.Activate();
            Assert.IsInstanceOf<ParameterlessConstructorClass>(result);
        }

        [Test]
        public void DynamicMock()
        {
            var result = (Mock<ILogger>)Mocker.DynamicMock(typeof(ILogger));
            Assert.IsInstanceOf<ILogger>(result.Object);
        }

    }
}