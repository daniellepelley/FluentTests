using System.Linq;
using System.Reflection;
using SutBuilder.Interfaces;

namespace SutBuilder
{
    public class ConstructorProvider
        : IConstructorProvider
    {
        public ConstructorInfo Get<T>()
            where T : class
        {
            return typeof(T)
                .GetConstructors()
                .OrderBy(x => x.GetParameters().Length)
                .ToArray()
                .FirstOrDefault();
        }
    }
}