using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using SutBuilder.Interfaces;

namespace SutBuilder
{
    public class ParameterlessConstructorProvider<T>
        : IConstructorProvider<T>
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