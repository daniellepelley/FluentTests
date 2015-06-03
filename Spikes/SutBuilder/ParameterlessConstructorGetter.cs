using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace SutBuilder
{
    public class ParameterlessConstructorGetter<T>
        : IConstructorGetter<T>
        where T : class
    {
        public ConstructorInfo Get()
        {
            var constructorInfo = typeof (T)
                .GetConstructors()
                .FirstOrDefault(x => !x.GetParameters().Any());

            if (constructorInfo == null)
            {
                throw new ConstructorNotFoundException("No parameterless constructor found");
            }
            return constructorInfo;
        }
    }
}