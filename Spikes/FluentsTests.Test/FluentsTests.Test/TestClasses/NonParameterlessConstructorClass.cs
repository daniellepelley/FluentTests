namespace FluentsTests.Test.TestClasses
{
    public class NonParameterlessConstructorClass
    {
        private string _status;
        private ILogger _logger;
        private IService _service;

        public NonParameterlessConstructorClass(ILogger logger, IService service)
        {
            _service = service;
            _logger = logger;
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