namespace AAATester.Tests
{
    public class TestableClass
    {
        private string _status;

        public TestableClass(string status)
        {
            Status = status;
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public string SetStatus(string status)
        {
            _status = status;
            return _status;
        }
    }
}
