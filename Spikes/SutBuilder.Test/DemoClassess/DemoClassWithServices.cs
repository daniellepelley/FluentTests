namespace SutBuilder.Test.DemoClassess
{
    public class DemoClassWithServices
    {
        public IServiceType1 SerivceType1 { get; private set; }
        public IServiceType2 ServiceType2 { get; private set; }

        public DemoClassWithServices(IServiceType1 serivceType1, IServiceType2 serviceType2)
        {
            SerivceType1 = serivceType1;
            ServiceType2 = serviceType2;
        }
    }
}