namespace Stubber.Tests.TestClasses
{
    public class MainClass
    {
        private readonly ILogger _logger;
        private readonly IService _service;

        public MainClass(ILogger logger, IService service)
        {
            _service = service;
            _logger = logger;
        }

        public ILogger Logger
        {
            get { return _logger; }
        }

        public IService Service
        {
            get { return _service; }
        }

        public void Log(string message)
        {
            _logger.Log(message);
        }

        public void CallService(string message)
        {
            _service.Run(message);
        }

    }
}