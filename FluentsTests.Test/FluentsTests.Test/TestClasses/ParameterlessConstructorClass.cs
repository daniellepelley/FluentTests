namespace FluentsTests.Test.TestClasses
{
    public class ParameterlessConstructorClass
    {
        private string _status;

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