using System.Reflection;

namespace SutBuilder.Interfaces
{
    public interface IConstructorProvider<T>
    {
        ConstructorInfo Get();
    }
}