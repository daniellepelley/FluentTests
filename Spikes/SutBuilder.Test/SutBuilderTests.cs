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
            var sutBuilder = new SutBuilder<DemoSimpleClass>(new ParameterlessConstructorGetter<DemoSimpleClass>(), new ClassConstructor<DemoSimpleClass>());
            var sut = sutBuilder.Build();
            Assert.IsNotNull(sut);
        }

        [Test]
        [ExpectedException(typeof(ConstructorNotFoundException))]
        public void SutBuilderWithParameterlessConstuctorException()
        {
            var sutBuilder = new SutBuilder<DemoClassWithServices>(new ParameterlessConstructorGetter<DemoClassWithServices>(), new ClassConstructor<DemoClassWithServices>());
            sutBuilder.Build();
        }

        [Test]
        public void SutBuilderWithConstuctorWithParameters()
        {
            var sutBuilder = new SutBuilder<DemoClassWithServices>(new ConstructorGetter<DemoClassWithServices>(), new MoqClassConstructor<DemoClassWithServices>());
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
    }
}
