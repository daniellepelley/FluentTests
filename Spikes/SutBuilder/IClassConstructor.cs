using System.Reflection;

namespace SutBuilder
{
    public interface IClassConstructor<T>
    {
        T Build(ConstructorInfo constructorInfo);
    }
}