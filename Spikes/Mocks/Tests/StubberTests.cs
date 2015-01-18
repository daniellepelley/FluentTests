using Moq;
using NUnit.Framework;
using Stubber.Tests.TestClasses;

namespace Stubber.Tests
{
    [TestFixture]
    public class StubberTests
    {
        [Test]
        public void ActivateCreatesInstanceOfTheClass()
        {
            var sut = new Mocker<MainClass>();

            var actual = sut.Activate();

            Assert.IsInstanceOf<MainClass>(actual);
        }

        [Test]
        public void ActivateCreatesInstanceOfTheClassWithPassedMock()
        {
            var sut = new Mocker<MainClass>();

            var mockLogger = new Mock<ILogger>();

            var mainClass = sut.Activate(mockLogger.Object);

            mainClass.Log("foo");
            
            mockLogger.Verify(x => x.Log(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void ActivateCreatesInstanceOfTheClassWithPassedMock2()
        {
            var sut = new Mocker<MainClass>();

            var mainClass = sut.Activate(Mock.Of<IService>());

            mainClass.Log("foo");

            sut.GetMock<ILogger>().Verify(x => x.Log(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void OldTest()
        {
            var mockLogger = new Mock<ILogger>();
            var mockService = new Mock<IService>();

            var sut = new MainClass(
                mockLogger.Object,
                mockService.Object);

            sut.Log("foo");
            sut.CallService("foo");
            sut.CallService("foo");

            mockLogger.Verify(x => x.Log("foo"), Times.Once);
            mockService.Verify(x => x.Run("foo"), Times.Exactly(2));
        }


        [Test]
        public void FluentStubber()
        {
            FluentMock<MainClass>
               .When(m =>
               {
                   m.Log("foo");
                   m.CallService("foo");
                   m.CallService("foo");
               })
               .Verify<ILogger>(x => x.Log("foo"), Times.Once)
               .Verify<IService>(x => x.Run("foo"), Times.Exactly(2));
        }

        [Test]
        public void FluentStubber2()
        {
            FluentMock<MainClass>
               .When(m =>
               {
                   m.Log("foo");
                   m.CallService("foo");
                   m.CallService("foo");
               })
               .Verify<ILogger>((x, m) => x == m.Logger)
               .Verify<IService>((x, m) => x == m.Service);
        }
    }
}
