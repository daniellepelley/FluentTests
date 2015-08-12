namespace SutBuilder.Moq
{
    public class MoqClassConstructor : ClassConstructor
    {
        public MoqClassConstructor()
            : base(new MoqDependencyResolver())
        { }
    }
}