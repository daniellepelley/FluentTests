using System.Reflection;

namespace SutBuilder.Interfaces
{
    public interface IClassConstructor<T>
    {
        T Build(ConstructorInfo constructorInfo);
    }
}