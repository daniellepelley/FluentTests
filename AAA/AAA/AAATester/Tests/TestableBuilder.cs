namespace AAATester.Tests
{
    public class TestableBuilder : IBuilder<TestableClass>
    {
        private string _status;

        public TestableClass Build()
        {
            return new TestableClass(_status);
        }

        public TestableBuilder WithStatus(string status)
        {
            _status = status;
            return this;
        }
    }
}
