using System.Linq;
using System.Reflection;

namespace SutBuilder
{
    public class ConstructorGetter<T>
        : IConstructorGetter<T>
        where T : class
    {
        public ConstructorInfo Get()
        {
            return typeof(T)
                .GetConstructors()
                .OrderBy(x => x.GetParameters().Length)
                .ToArray()
                .FirstOrDefault();
        }
    }
}