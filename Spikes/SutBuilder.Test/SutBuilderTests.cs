using NUnit.Framework;
using SutBuilder.Moq;
using SutBuilder.Test.DemoClassess;

namespace SutBuilder.Test
{
    public class SutBuilderTests
    {
        [Test]
        public void SutBuilderWithParameterlessConstuctor()
        {
            var sutBuilder = new SutBuilder<DemoSimpleClass>(new ParameterlessConstructorProvider(), new ClassConstructor());
            var sut = sutBuilder.Build();
            Assert.IsNotNull(sut);
        }

        [Test]
        [ExpectedException(typeof(ConstructorNotFoundException))]
        public void SutBuilderWithParameterlessConstuctorException()
        {
            var sutBuilder = new SutBuilder<DemoClassWithServices>(new ParameterlessConstructorProvider(), new ClassConstructor());
            sutBuilder.Build();
        }

        [Test]
        public void SutBuilderWithConstuctorWithParameters()
        {
            var sutBuilder = new SutBuilder<DemoClassWithServices>(new ConstructorProvider(), new MoqClassConstructor());
            var sut = sutBuilder.Build();
            Assert.IsNotNull(sut);
        }

        [Test]
        public void SutBuilderStubs()
        {
            var sutBuilder = new SutBuilder();
            var sut = sutBuilder.Build();
            Assert.IsNotNull(sut);
        }

        [Test]
        public void StaticSutBuilderCanBuilderParameterlessClass()
        {
            var sut = Sut.Create<DemoSimpleClass>();
            Assert.IsNotNull(sut);
        }

        [Test]
        public void StaticSutBuilderCanBuilderWithConstuctorParameters()
        {
            Sut.SetClassConstructor(new MoqClassConstructor());
            var sut = Sut.Create<DemoClassWithServices>();
            Assert.IsNotNull(sut);
        }
    }
}
