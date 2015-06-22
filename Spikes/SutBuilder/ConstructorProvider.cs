using System.Linq;
using System.Reflection;
using SutBuilder.Interfaces;

namespace SutBuilder
{
    public class ConstructorProvider<T>
        : IConstructorProvider<T>
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