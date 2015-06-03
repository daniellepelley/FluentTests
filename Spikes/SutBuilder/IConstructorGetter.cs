using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace SutBuilder
{
    public interface IConstructorGetter<T>
    {
        ConstructorInfo Get();
    }
}