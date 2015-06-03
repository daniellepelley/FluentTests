using System.Linq;
using System.Reflection;

namespace SutBuilder.Moq
{
    public class MoqClassConstructor<T> : ClassConstructor<T>
    {
        public MoqClassConstructor()
            : base(new MoqDependencyResolver())
        { }
    }
}