using System.Reflection;

namespace SutBuilder.Interfaces
{
    public interface IConstructorProvider
    {
        ConstructorInfo Get<T>()
            where T : class;
    }
}