using System.Reflection;

namespace SutBuilder.Interfaces
{
    public interface IClassConstructor
    {
        T Build<T>(ConstructorInfo constructorInfo);
    }
}