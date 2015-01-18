using FluentsTests.Test.TestClasses;
using FluentTests;
using FluentTests.Moq;
using NUnit.Framework;

namespace FluentsTests.Test
{
    public class SutBuilderTests
    {
        [Test]
        public void CreatesAnInstanceOfClassWithParameterlessConstructor()
        {
            var sut = new SutBuilder<ParameterlessConstructorClass>();
            var result = sut.Build();
            Assert.IsInstanceOf<ParameterlessConstructorClass>(result);
        }

        [Test]
        public void CreatesAnInstanceOfClassWithParameterlessConstructorUsingMoq()
        {
            var sut = new MoqSutBuilder<ParameterlessConstructorClass>();
            var result = sut.Build();
            Assert.IsInstanceOf<ParameterlessConstructorClass>(result);
        }

        [Test]
        public void CreatesAnInstanceOfClassWithNonParameterlessConstructor()
        {
            var sut = new MoqSutBuilder<NonParameterlessConstructorClass>();
            var result = sut.Build();
            Assert.IsInstanceOf<NonParameterlessConstructorClass>(result);
        }
    }
}